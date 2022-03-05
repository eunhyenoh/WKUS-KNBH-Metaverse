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
            //Debug.Log("������!!!@");
            PhotonNetwork.AutomaticallySyncScene = false;   //�������� ��� false �׷��� �ٸ� �÷��̾� ���� �����Ͱ� �ϴ°� ������ �ȵɵ�?
            //�ؿ� start��ư �����͸� ���� �� �ְ� ������������ ���� �����Ұ� �ڡ�
        }
        // ���� �߰���Ų�� if�� �̰� ���Ŀ� ��ġ �����ϱ� (��ư�� �ְų� �ٸ��Լ��� �־ Instance�� �ҷ�������)
      /*  if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.Disconnect();
        }*/
    }
    public void player_DisConnect()
    {
        PhotonNetwork.Disconnect();
    }
    //���� �߰���Ų�� public override void OnDisconnected()
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
        // �� �� �κ��� �� �渶�� ���� �޾Ƽ� �������ݽô�.
        // ����� �濡 ���� �տ� ���ڰ� ���� 
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
            Destroy(trans.gameObject); //�븮��Ʈ ������Ʈ�� �����. 
        }

        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            //�����Ӱ� ����� ���ڸ��� 3������ ������ �����Ӱ��� �ɷ��� what_scene_go�� 3�� ������ Create�� ���Դٴ°� �� �� �ְ� ����(���� ����)
            if (roomList[i].Name[0].Equals('P') && what_Scene_Go == 2)
            {
                Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
            }
            else if (roomList[i].Name[0].Equals('B') && what_Scene_Go == 3) //�긴�� ����� ���ڸ��� 4������ ������ �긴���� �ɷ��� 
            {
                Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
            }
            else if (roomList[i].Name[0].Equals('F') && what_Scene_Go == 4) //����ȭ ����� ���ڸ��� 5������ ������ ����ȭ �ɷ��� 
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

    /* Find Room ���� �ذ� ���ؼ� ���� ================================================*/

    public void CreateRoomName()    //����� �������� �տ� ���ڰ� ���� 
    {
        if (what_Scene_Go == 2)  //������
        {
            PhotonNetwork.CreateRoom("Prime_" + roomNameInputField.text);
        }
        else if (what_Scene_Go == 3)//�긴��
        {
            PhotonNetwork.CreateRoom("Bridge_" + roomNameInputField.text);
        }
        else if (what_Scene_Go == 4) //����ȭ
        {
            PhotonNetwork.CreateRoom("Flower_" + roomNameInputField.text);
        }
    }

    /*===========================================================================*/
}
