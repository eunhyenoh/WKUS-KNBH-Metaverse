using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class WRManager : MonoBehaviourPunCallbacks
{
    
    public static WRManager Instance;
    [Header("대기방에서 작동할 코드들입니다.")]
    public int waitingRoomNumber;   //여기 안에 로비 빌드씬 숫자
    public int whereSceneGo;        //여기 안에 이동할 숫자 

    private void Awake()
    {
        Instance = this;
        PhotonNetwork.AutomaticallySyncScene = false;
        PhotonNetwork.ConnectUsingSettings();       //대기방 입장시 바로 서버 다시 접속 
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master2");   //추후에 주석해주기 
        PhotonNetwork.JoinRandomRoom(); //바로 랜덤룸 입장? X 프라임 수덕호 가려서 입장해야한다. 
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("방입장 실패 방을 생성합니다2.");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }
    public override void OnJoinedRoom()
    {
        Debug.LogWarning("성공적으로 방에 입장하였습니다.2★" );
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
        PhotonNetwork.LoadLevel(waitingRoomNumber);         //여기에 무조건 대기방 넣어야함 아니면 에러남 
        // PhotonNetwork.ConnectUsingSettings();   //접속이 끊기면 다시 접속하게 함 w
    }
}
