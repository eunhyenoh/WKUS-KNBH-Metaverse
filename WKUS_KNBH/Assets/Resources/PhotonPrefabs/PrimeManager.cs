using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// ī�޶� �������°� �����Ű���� �ؿ� 3�� ��� �߰�, MonoBehaviourPunCallbacks�� ���� 
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;


public class PrimeManager : MonoBehaviourPunCallbacks
{
    public static PrimeManager Instance;

    public GameObject stamp_button; //������ ��� ������ �� 

    public GameObject[] stamp;      //������ ������ �� (�̹����� ������?)

    public Image[] stamp_Image;     //���⿡ ���� �־���� �ε������ñ� ���� �ȶ�

    public GameObject check_stamp;  // ������ �г� ������ �� 

    public GameObject cctv_Pannel;  // ķ�۽� ���� ������ ���� �г� 

    public GameObject player;   //Bear_s PlayerController �ִ¾� �־��ָ�� (CCTV������ ���ѽ�Ű����)
    public PhotonView PV;
    private void Start()
    {
        Instance = this;
        // ������ �̹����� �޾ƿ� 
        for (int i = 0; i < stamp.Length; i++)
        {
            stamp_Image[i] = stamp[i].GetComponent<Image>();
            //Debug.Log(i + "��° �̹��� ����");
        }
    }
    private void Update()
    {
        if (PV.IsMine)
        {
            if (player.transform.position.y <= -30)
            {
                player.transform.position = new Vector3(0f, 5f, 0f);
            }
        }
    }

    //���� �������� ���������� 
    public void FadeIn(int number)
    {
        IEnumerator FadeIn()
        {
            Debug.Log("���̵��� ����");
            float fadeCount = 0.3f;
            while (fadeCount <= 1f)
            {
                fadeCount += 0.005f;
                yield return new WaitForSeconds(0.01f); //0.01�ʸ��� ����
                stamp_Image[number].color = new Color(255, 255, 255, fadeCount);
            }
        }
        StartCoroutine(FadeIn());
    }

    //Game�� ���� ������ on off
    public void Stamp_On()
    {
        check_stamp.SetActive(true);
    }

    public void Stamp_Off()
    {
        check_stamp.SetActive(false);
    }

    /*ī�޶� CCTV���� ��ũ��Ʈ�� =====================================================*/

    //CCTV �������� CameraRotation ������� 
    /*
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex == 2)
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "CameraRotation"), Vector3.zero, Quaternion.identity);
            //Destroy(gameObject);
        }
    }*/

    public void CCTV_PannelOn_Off()
    {
        if (cctv_Pannel.activeSelf == true)
        {
            cctv_Pannel.SetActive(false);
        }
        else
        {
            cctv_Pannel.SetActive(true);
        }
    }

    public void View_CCTVl(int i)   //�������б� ��ü ���� ������ �� 
    {
        CameraManager.Instance.On_CameraPoint(i);
        //CameraManager.Instance.On_CameraPoint(i);
        //player.GetComponent<PlayerController>().enabled = false;    //ĳ���� �������̰� ��Ȱ��ȭ       
    }
    public void CCTV_OFF()
    {
        CameraManager.Instance.Off_CameraPoint();
        //CameraManager.Instance.Off_CameraPoint();
    }

  
    /*
    public void View_Prime()    //������
    {
        gameObject.GetComponent<PlayerController>().enabled = false;    //ĳ���� �������̰� ��Ȱ��ȭ
    }
    public void View_0Dae() //����
    {
        gameObject.GetComponent<PlayerController>().enabled = false;    //ĳ���� �������̰� ��Ȱ��ȭ
    }
    public void View_Student()  //�л�ȸ��
    {
        gameObject.GetComponent<PlayerController>().enabled = false;    //ĳ���� �������̰� ��Ȱ��ȭ
    }
    public void View_Soongsil() //���� ���� 
    {
        gameObject.GetComponent<PlayerController>().enabled = false;    //ĳ���� �������̰� ��Ȱ��ȭ
    }
    */
    /* ===============================================================================*/


}
