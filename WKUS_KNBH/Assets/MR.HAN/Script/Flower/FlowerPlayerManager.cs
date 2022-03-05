using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class FlowerPlayerManager : MonoBehaviourPunCallbacks
{
    public AudioSource sound;    //무궁화 총맞는거 소리 

    Vector3 playerPosition;     //현재 플레이어 포지션
    Vector3 stopPlayerPosition; //정지해야할 포지션 구하기 playerPosition과 비교 후 이 값과 다르면 죽임 처리

    public GameObject GameClear_Pannel;
    public GameObject GameOver_Pannel;

    PhotonView PV;
    // FlowerPlayerManage에서 사용 
    bool lockPosition = true;
    bool finish = false;    //피니시라인 통과하면 움직여도 안죽게 하려고 만듬 
    void Start()
    {
        //사운드를 배열로 가져옴 
        PV = GetComponent<PhotonView>();
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PV.IsMine)
        {
            FlowerPlayerManage();  // 꽃에 맞는 플레이어 셋팅    
        }
        //FlowerPlayerManage();  // 꽃에 맞는 플레이어 셋팅    
    }

    private void OnTriggerEnter(Collider other)
    {
        //피니시라인 넘으면 
        if (other.tag == "Finish_Line")
        {
            Debug.Log("피니시 라인 통과");
            finish = true;
            GameClear_Pannel.SetActive(true);   //게임 클리어 화면 패널 켜줌 
        }
    }

    /* 게임 관련 플레이어 관리 함수---------------------------------------------------------------------------------*/
    public void FlowerPlayerManage()
    {
        playerPosition = new Vector3(Mathf.Floor(this.gameObject.transform.position.x*100), Mathf.Floor(this.gameObject.transform.position.y*100),
                                     Mathf.Floor(this.gameObject.transform.position.z*100));
        Debug.Log("플레이어 현재 포지션:"+playerPosition);
        Debug.Log("현재 플레이어 위치 : " + playerPosition);
        //만약 무궁화 끝났으면 (움직이면 죽을 때)
        if (!FlowerManager.canrun)
        {
            //정지포지션 구하기 
            if (lockPosition)
            {   //가만히 있어야 될 포지션 구함 (정지된 포지션)
                stopPlayerPosition = playerPosition;
                lockPosition = false;
                Debug.Log("stop포지션" + stopPlayerPosition);
            }
            if ((stopPlayerPosition != playerPosition) && !finish)   //포지션이 일치하지않고 finish라인 안넘었다면 
            {
                Debug.Log("사망이요!!");
                sound.Play();       //추후에 수정 
                GameOver_Pannel.SetActive(true);
              // 추후에 애니메이션 추가 
            }
        }
        else if (FlowerManager.canrun)
        {
            //다음 고정 포지션 구해야되니 true로 변경 
            lockPosition = true;
        }
    }
    public void Back_Btn()
    {
        Launcher.Instance.player_DisConnect();
    }
    /*-----------------------------------------------------------------------------------------------------------*/
}

// 할거 ★★★★★★★★★
// 무궁화에 죽을 때 총 맞는거 넣어주기, position에 *100하고 소수점 버리게 하고 비교?
// 브릿지에서는 유리 깨지는 소리 추가시키기, 끝에 이동하면 GameClear 패널 나오게 하기 

/*------------------------------------------------------------------------
 스크립트 설명 - 무궁화 꽃이 플레이어 매니저 

·playerController 프리팹에 들어갈 코드입니다. 

WhereScene()
플레이어가 존재하는 씬에 따라서 밑의 게임과 관련된 함수들을 쓸 수 있게 boolean값들을 조정

GameOver() 
게임에서 클리어했을때 죽었을때 나오는 패널 밑에 버튼 이벤트 

FlowerPlayerManage
음악재생이 종료되면(움직이면 안됨) 플레이어의 정지된 포지션을 구하고
만약 그 포지션이 음악재생이 시작되기 전까지 맞지 않으면 GameOver UI를 띄워줍니다.
만약 무궁화 끝에있는 finish라인을 넘으면 GameClear UI가 나옵니다. 

BridgeManage()
브릿지에서 쓰이는 코드 해당 아래축 밑으로 떨어지면 사망 UI나옴
 -----------------------------------------------------------------------*/