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
    public void SearchGame()    //��ư ������ ������ ���� �� ���� �� �������̵� �Լ��� ���ؼ� �ٷ� �����Ӱ����� �̵��� 
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");   //���Ŀ� �ּ����ֱ� 
        PhotonNetwork.JoinRandomRoom();
        //PhotonNetwork.AutomaticallySyncScene = false; �����ϰ� �ѹ��� �Ѿ�� false�� �������ֱ� 
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("������ ���� ���� �����մϴ�.");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }
    public override void OnJoinedRoom()
    {
        Debug.LogWarning("���������� �濡 �����Ͽ����ϴ�.��" + game + game2);
        PhotonNetwork.LoadLevel(2); //�� ó�� �����Ӱ����� ���� (���� �����ӳ��γ� ����ȣ�� �� �̵��� ���ؼ� �� �� ���� 

    }

    public void player_Disconnect() //Test Game������ �̵� 
    {
        //SceneManager.LoadScene();
        //Debug.Log("1�� �����");
        PhotonNetwork.Disconnect();
    }

    public void player_Disconnect2()    //�����ӿ��� �긴��?
    {
        SceneManager.LoadScene(2);
        Debug.Log("2�� �����");
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log($"Disconected due to: {cause}");
        //SceneManager.LoadScene(6);  //�������� �̵� ���⿡�� �� �ٽ� �����ϰ� ���� ���� (GoGame1,RetTrunPrime ����)
    }

    //���࿡ �̹� ������ �������̸� ������ü ���ְ� �װ� �ƴ϶�� ������ �̵���Ŵ 
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
        Debug.Log("GoGame1 ����");
        game = true;
        player_Disconnect();
    }
    public void GoGame2()
    {
        Debug.Log("GoGame2 ����");
        game = false;
        player_Disconnect2();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�����ӸŴ��� Ʈ���� ����Ȯ���߽��ϴ�.");
        if (other.tag == "PrimeIn")
        {
            GoScene(8);    //�����Ӱ�In���� �־��ֱ�           
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
