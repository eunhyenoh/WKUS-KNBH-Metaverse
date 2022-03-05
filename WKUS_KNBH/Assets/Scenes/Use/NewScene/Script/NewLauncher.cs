using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NewLauncher : MonoBehaviourPunCallbacks
{
    public static NewLauncher Instance;

    public bool game = false;
    public bool game2 = false;
    private void Awake()
    {
        Instance = this;
        PhotonNetwork.AutomaticallySyncScene = false;
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "PrimeWR" || SceneManager.GetActiveScene().name == "PrimeInWR" ||
            SceneManager.GetActiveScene().name == "AuditoriumWR" || SceneManager.GetActiveScene().name == "BridegWR"
            || SceneManager.GetActiveScene().name == "FlowerWR")
        {
            Destroy(this);
        }
    }
    public void SearchGame()    //버튼 누르면 서버에 접속 그 이후 밑 오버라이드 함수에 의해서 바로 프라임관으로 이동함 
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");   //추후에 주석해주기 
        PhotonNetwork.JoinRandomRoom();
        //PhotonNetwork.AutomaticallySyncScene = false; 방장하고 한번에 넘어가면 false로 변경해주기 
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("방입장 실패 방을 생성합니다.");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }
    public override void OnJoinedRoom()
    {
        Debug.LogWarning("성공적으로 방에 입장하였습니다.★" + game + game2);
        PhotonNetwork.LoadLevel(2); //맨 처음 프라임관으로 입장 (이후 프라임내부나 수덕호는 방 이동을 통해서 갈 수 있음 

    }

    public void player_Disconnect() //Test Game씬으로 이동 
    {
        //SceneManager.LoadScene();
        //Debug.Log("1이 실행됨");
        PhotonNetwork.Disconnect();
    }

    public void player_Disconnect2()    //프라임에서 브릿지?
    {
        SceneManager.LoadScene(2);
        Debug.Log("2가 실행됨");
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Disconected due to: {cause}");
        //SceneManager.LoadScene(6);  //대기방으로 이동 여기에서 방 다시 접속하고 입장 관리 (GoGame1,RetTrunPrime 참고)
    }

    //만약에 이미 서버에 접속중이면 연결해체 해주고 그게 아니라면 씬으로 이동시킴 
    public void GoScene(int i)
    {
        if (PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene(i);
            player_Disconnect();
        }
        else
        {
            SceneManager.LoadScene(i);
            player_Disconnect();
        }
    }

    public void GoGame1()
    {
        Debug.Log("GoGame1 실행");
        game = true;
        player_Disconnect();
    }
    public void GoGame2()
    {
        Debug.Log("GoGame2 실행");
        game = false;
        player_Disconnect2();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("프라임매니저 트리거 진입확인했습니다.");
        if (other.tag == "PrimeIn")
        {
            GoScene(8);    //프라임관In대기방 넣어주기           
        }
        else if(other.tag =="Go_Prime")
        {
            GoScene(7);
        }
        else if (other.tag == "Hall_Portal")
        {
            GoScene(9);
        }
        else if (other.tag == "Go_Bridge")
        {
            GoScene(10);
        }
    }
}
