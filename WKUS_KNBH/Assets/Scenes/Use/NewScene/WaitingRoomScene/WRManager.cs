using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class WRManager : MonoBehaviourPunCallbacks
{
    
    public static WRManager Instance;
    [Header("���濡�� �۵��� �ڵ���Դϴ�.")]
    public int waitingRoomNumber;   //���� �ȿ� �κ� ����� ����
    public int whereSceneGo;        //���� �ȿ� �̵��� ���� 

    private void Awake()
    {
        Instance = this;
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.ConnectUsingSettings();       //���� ����� �ٷ� ���� �ٽ� ���� 
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master2");   //���Ŀ� �ּ����ֱ� 
        PhotonNetwork.JoinRandomRoom(); //�ٷ� ������ ����? X ������ ����ȣ ������ �����ؾ��Ѵ�. 
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("������ ���� ���� �����մϴ�2.");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }
    public override void OnJoinedRoom()
    {
        Debug.LogWarning("���������� �濡 �����Ͽ����ϴ�.2��" );
        PhotonNetwork.LoadLevel(whereSceneGo);
    }

    public void player_Disconnect()
    {
        PhotonNetwork.Disconnect();
        //game = true;
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Disconected due to: {cause}");
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.LoadLevel(waitingRoomNumber);         //���⿡ ������ ���� �־���� �ƴϸ� ������ 
        // PhotonNetwork.ConnectUsingSettings();   //������ ����� �ٽ� �����ϰ� �� w
    }
}
