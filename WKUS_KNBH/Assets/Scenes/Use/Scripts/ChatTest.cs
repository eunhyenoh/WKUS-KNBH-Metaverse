using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon.Chat;
using AuthenticationValues = Photon.Chat.AuthenticationValues;
using ExitGames.Client.Photon;
using System;

public class ChatTest : MonoBehaviour, IChatClientListener
{
    private ChatClient chatClient;
    private string userName;
    private string currentChannelName;

    public InputField inputFieldChat;
    public Text currentChannelText;
    public Text outputText;

    void Start()
    {
        Application.runInBackground = true;
        userName = (PhotonNetwork.NickName + "   " + DateTime.Now.ToShortTimeString()); // 현재 시간과 닉네임 
        currentChannelName = "Campus Tour";

        chatClient = new ChatClient(this);

        chatClient.UseBackgroundWorkerForSending = true;
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, "1.0", new AuthenticationValues(userName));
        AddLine(string.Format("연결시도", userName));
    }

    public void AddLine(string lineString)
    {
        outputText.text += lineString + "\r\n";
    }

    public void OnApplicationQuit()
    {
        if(chatClient != null)
        {
            chatClient.Disconnect();
        }
    }

    public void DebugReturn(ExitGames.Client.Photon.DebugLevel level, string message)
    {
        if(level == ExitGames.Client.Photon.DebugLevel.ERROR)
        {
            Debug.LogError(message);
        }
        else if(level == ExitGames.Client.Photon.DebugLevel.WARNING)
        {
            Debug.LogWarning(message);
        }
        else
        {
            Debug.Log(message);
        }
    }

    public void OnConnected()
    {
        AddLine("서버에 연결되었습니다.");

        chatClient.Subscribe(new string[] { currentChannelName }, 10);
    }

    public void OnDisconnected()
    {
        AddLine("서버에 연결이 끊어졌습니다.");
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log("OnChatStateChange = " + state);
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        AddLine(string.Format("채널 입장 ({0})", string.Join(",", channels)));
    }

    public void OnUnsubscribed(string[] channels)
    {
        AddLine(string.Format("채널 퇴장({0})", string.Join(",", channels)));
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        if (channelName.Equals(currentChannelName))
        {
            this.ShowChannel(currentChannelName);
        }
    }

    public void ShowChannel(string channelName)
    {
        if (string.IsNullOrEmpty(channelName))
            {
            return;
        }

        ChatChannel channel = null;
        bool found = this.chatClient.TryGetChannel(channelName, out channel);
        if (!found)
        {
            Debug.Log("ShowChannel failed to find channel: " + channelName);
            return;
        }

        this.currentChannelName = channelName;
        this.currentChannelText.text = channel.ToStringMessages();
        Debug.Log("ShowChannel: " + currentChannelName);
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        Debug.Log("OnPrivateMessage: " + message);
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log("status: " + string.Format("{0} is {1}, Msg: {2}", user, status, message));
    }


    void Update()
    {
        chatClient.Service();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnEnterSend()
    {
        if(Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            this.SendChatMessage(this.inputFieldChat.text);
            this.inputFieldChat.text = "";
        }
    }

    private void SendChatMessage(string inputLine)
    {
        if (string.IsNullOrEmpty(inputLine))
        {
            return;
        }

        this.chatClient.PublishMessage(currentChannelName, inputLine);
    }
}
