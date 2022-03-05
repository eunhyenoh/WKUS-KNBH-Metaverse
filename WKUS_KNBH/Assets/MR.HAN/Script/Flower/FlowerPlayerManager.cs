using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class FlowerPlayerManager : MonoBehaviourPunCallbacks
{
    public AudioSource sound;    //����ȭ �Ѹ´°� �Ҹ� 

    Vector3 playerPosition;     //���� �÷��̾� ������
    Vector3 stopPlayerPosition; //�����ؾ��� ������ ���ϱ� playerPosition�� �� �� �� ���� �ٸ��� ���� ó��

    public GameObject GameClear_Pannel;
    public GameObject GameOver_Pannel;

    PhotonView PV;
    // FlowerPlayerManage���� ��� 
    bool lockPosition = true;
    bool finish = false;    //�ǴϽö��� ����ϸ� �������� ���װ� �Ϸ��� ���� 
    void Start()
    {
        //���带 �迭�� ������ 
        PV = GetComponent<PhotonView>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PV.IsMine)
        {
            FlowerPlayerManage();  // �ɿ� �´� �÷��̾� ����    
        }
        //FlowerPlayerManage();  // �ɿ� �´� �÷��̾� ����    
    }

    private void OnTriggerEnter(Collider other)
    {
        //�ǴϽö��� ������ 
        if (other.tag == "Finish_Line")
        {
            Debug.Log("�ǴϽ� ���� ���");
            finish = true;
            GameClear_Pannel.SetActive(true);   //���� Ŭ���� ȭ�� �г� ���� 
        }
    }

    /* ���� ���� �÷��̾� ���� �Լ�---------------------------------------------------------------------------------*/
    public void FlowerPlayerManage()
    {
        playerPosition = new Vector3(Mathf.Floor(this.gameObject.transform.position.x*100), Mathf.Floor(this.gameObject.transform.position.y*100),
                                     Mathf.Floor(this.gameObject.transform.position.z*100));
        Debug.Log("�÷��̾� ���� ������:"+playerPosition);
        Debug.Log("���� �÷��̾� ��ġ : " + playerPosition);
        //���� ����ȭ �������� (�����̸� ���� ��)
        if (!FlowerManager.canrun)
        {
            //���������� ���ϱ� 
            if (lockPosition)
            {   //������ �־�� �� ������ ���� (������ ������)
                stopPlayerPosition = playerPosition;
                lockPosition = false;
                Debug.Log("stop������" + stopPlayerPosition);
            }
            if ((stopPlayerPosition != playerPosition) && !finish)   //�������� ��ġ�����ʰ� finish���� �ȳѾ��ٸ� 
            {
                Debug.Log("����̿�!!");
                sound.Play();       //���Ŀ� ���� 
                GameOver_Pannel.SetActive(true);
              // ���Ŀ� �ִϸ��̼� �߰� 
            }
        }
        else if (FlowerManager.canrun)
        {
            //���� ���� ������ ���ؾߵǴ� true�� ���� 
            lockPosition = true;
        }
    }
    public void Back_Btn()
    {
        Launcher.Instance.player_DisConnect();
    }
    /*-----------------------------------------------------------------------------------------------------------*/
}

// �Ұ� �ڡڡڡڡڡڡڡڡ�
// ����ȭ�� ���� �� �� �´°� �־��ֱ�, position�� *100�ϰ� �Ҽ��� ������ �ϰ� ��?
// �긴�������� ���� ������ �Ҹ� �߰���Ű��, ���� �̵��ϸ� GameClear �г� ������ �ϱ� 

/*------------------------------------------------------------------------
 ��ũ��Ʈ ���� - ����ȭ ���� �÷��̾� �Ŵ��� 

��playerController �����տ� �� �ڵ��Դϴ�. 

WhereScene()
�÷��̾ �����ϴ� ���� ���� ���� ���Ӱ� ���õ� �Լ����� �� �� �ְ� boolean������ ����

GameOver() 
���ӿ��� Ŭ���������� �׾����� ������ �г� �ؿ� ��ư �̺�Ʈ 

FlowerPlayerManage
��������� ����Ǹ�(�����̸� �ȵ�) �÷��̾��� ������ �������� ���ϰ�
���� �� �������� ��������� ���۵Ǳ� ������ ���� ������ GameOver UI�� ����ݴϴ�.
���� ����ȭ �����ִ� finish������ ������ GameClear UI�� ���ɴϴ�. 

BridgeManage()
�긴������ ���̴� �ڵ� �ش� �Ʒ��� ������ �������� ��� UI����
 -----------------------------------------------------------------------*/