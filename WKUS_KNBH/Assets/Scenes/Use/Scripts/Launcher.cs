using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Linq;
using UnityEngine.SceneManagement;
public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;

    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject PlayerListItemPrefab;
    [SerializeField] GameObject startGameButton;
    public static int what_Scene_Go;

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            //Debug.Log("마스터!!!@");
            PhotonNetwork.AutomaticallySyncScene = false;   //마스터일 경우 false 그러면 다른 플레이어 한테 마스터가 하는거 적용이 안될듯?
            //밑에 start버튼 마스터만 누를 수 있게 설정되있으니 추후 수정할것 ★★
        }
        // 내가 추가시킨거 if문 이거 추후에 위치 변경하기 (버튼에 넣거나 다른함수에 넣어서 Instance로 불러오든지)
      /*  if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.Disconnect();
        }*/
    }
    public void player_DisConnect()
    {
        PhotonNetwork.Disconnect();
    }
    //내가 추가시킨거 public override void OnDisconnected()
    public override void OnDisconnected(DisconnectCause cause)
    {
        SceneManager.LoadScene(1);
    }

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
       // Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();
 
    }

    public override void OnConnectedToMaster()
    {
       // Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
      PhotonNetwork.AutomaticallySyncScene = false;
    }
    public override void OnJoinedLobby()
    {
        MenuManager.Instance.OpenMenu("title");
        //Debug.Log("Joined Lobby");
    }

    public void CreateRoom()
    {       
        if (string.IsNullOrEmpty(roomNameInputField.text))
        {
            return;
        }
        // original 
        //PhotonNetwork.CreateRoom(roomNameInputField.text);
        // ★ 이 부분을 각 방마다 변수 받아서 수정해줍시다.
        // 만드는 방에 따라 앞에 숫자가 붙음 
        CreateRoomName();
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
       // MenuManager.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;

        foreach (Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }

     startGameButton.SetActive(PhotonNetwork.IsMasterClient);
        PhotonNetwork.LoadLevel(what_Scene_Go);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
           startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }
    
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "Room Creation Failed: " + message;
        Debug.LogError("Room Creaton Failed: " + message);
        MenuManager.Instance.OpenMenu("error");
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(2);
    }
  
public void FlowerScene()
    {
        PhotonNetwork.LoadLevel(4);
    }

    public void BridgeScene()
    {
        PhotonNetwork.LoadLevel(3);
    }

    public void Game()
    {
        PhotonNetwork.LoadLevel(2);
    }

    public void Sample()
    {
        PhotonNetwork.JoinLobby();
    }
  

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject); //룸리스트 업데이트시 지운다. 
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            //프라임관 만들면 앞자리가 3임으로 같으면 프라임관만 걸러냄 what_scene_go이 3은 프라임 Create룸 들어왔다는걸 알 수 있게 선언(밑은 동일)
            if (roomList[i].Name[0].Equals('P') && what_Scene_Go == 2)
            {
                Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
            }
            else if (roomList[i].Name[0].Equals('B') && what_Scene_Go == 3) //브릿지 만들면 앞자리가 4임으로 같으면 브릿지만 걸러냄 
            {
                Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
            }
            else if (roomList[i].Name[0].Equals('F') && what_Scene_Go == 4) //무궁화 만들면 앞자리가 5임으로 같으면 무궁화 걸러냄 
            {
                Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
            }
            else
            {
                continue;
            }
            //Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
        //Debug.Log("OnRoomListUpdate() ")
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }

    /* Find Room 에러 해결 위해서 선언 ================================================*/

    public void CreateRoomName()    //만드는 씬에따라서 앞에 숫자가 붙음 
    {
        if (what_Scene_Go == 2)  //프라임
        {
            PhotonNetwork.CreateRoom("Prime_" + roomNameInputField.text);
        }
        else if (what_Scene_Go == 3)//브릿지
        {
            PhotonNetwork.CreateRoom("Bridge_" + roomNameInputField.text);
        }
        else if (what_Scene_Go == 4) //무궁화
        {
            PhotonNetwork.CreateRoom("Flower_" + roomNameInputField.text);
        }
    }

    /*===========================================================================*/
}
