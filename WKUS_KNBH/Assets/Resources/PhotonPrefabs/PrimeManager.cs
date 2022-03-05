using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// 카메라 빙빙도는거 빌드시키려고 밑에 3개 헤더 추가, MonoBehaviourPunCallbacks로 변경 
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;


public class PrimeManager : MonoBehaviourPunCallbacks
{
    public static PrimeManager Instance;

    public GameObject stamp_button; //스탬프 찍기 넣으면 됨 

    public GameObject[] stamp;      //스템프 넣으면 됨 (이미지로 관리됨?)

    public Image[] stamp_Image;     //여기에 숫자 넣어놔야 인덱스뭐시기 에러 안뜸

    public GameObject check_stamp;  // 스템프 패널 넣으면 됨 

    public GameObject cctv_Pannel;  // 캠퍼스 투어 누르면 나올 패널 

    public GameObject player;   //Bear_s PlayerController 있는애 넣어주면됨 (CCTV움직임 제한시키려고)
    public PhotonView PV;
    private void Start()
    {
        Instance = this;
        // 스템프 이미지를 받아옴 
        for (int i = 0; i < stamp.Length; i++)
        {
            stamp_Image[i] = stamp[i].GetComponent<Image>();
            //Debug.Log(i + "번째 이미지 넣음");
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

    //점점 스탬프가 선명해지게 
    public void FadeIn(int number)
    {
        IEnumerator FadeIn()
        {
            Debug.Log("페이드인 실행");
            float fadeCount = 0.3f;
            while (fadeCount <= 1f)
            {
                fadeCount += 0.005f;
                yield return new WaitForSeconds(0.01f); //0.01초마다 실행
                stamp_Image[number].color = new Color(255, 255, 255, fadeCount);
            }
        }
        StartCoroutine(FadeIn());
    }

    //Game에 쓰일 스템프 on off
    public void Stamp_On()
    {
        check_stamp.SetActive(true);
    }

    public void Stamp_Off()
    {
        check_stamp.SetActive(false);
    }

    /*카메라 CCTV관련 스크립트들 =====================================================*/

    //CCTV 프리팹인 CameraRotation 만들어줌 
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

    public void View_CCTVl(int i)   //원광대학교 전체 보기 눌렀을 시 
    {
        CameraManager.Instance.On_CameraPoint(i);
        //CameraManager.Instance.On_CameraPoint(i);
        //player.GetComponent<PlayerController>().enabled = false;    //캐릭터 못움직이게 비활성화       
    }
    public void CCTV_OFF()
    {
        CameraManager.Instance.Off_CameraPoint();
        //CameraManager.Instance.Off_CameraPoint();
    }

  
    /*
    public void View_Prime()    //프라임
    {
        gameObject.GetComponent<PlayerController>().enabled = false;    //캐릭터 못움직이게 비활성화
    }
    public void View_0Dae() //공대
    {
        gameObject.GetComponent<PlayerController>().enabled = false;    //캐릭터 못움직이게 비활성화
    }
    public void View_Student()  //학생회관
    {
        gameObject.GetComponent<PlayerController>().enabled = false;    //캐릭터 못움직이게 비활성화
    }
    public void View_Soongsil() //숭실 기념관 
    {
        gameObject.GetComponent<PlayerController>().enabled = false;    //캐릭터 못움직이게 비활성화
    }
    */
    /* ===============================================================================*/


}
