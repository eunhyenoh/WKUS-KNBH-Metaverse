using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    public static bool canrun = false;  //움직여도 될 때 true, 움직이면 안될 때 false
    bool issong = true;   // false면 조건문에서 걸러져서 노래재생 안됨.


    public float cooltime = 5;  // 추후에 쿨타임 랜덤하게 변경 

    AudioSource flower; //무궁화 사운드 소스 


    // Start is called before the first frame update
    void Start()
    {
        //무궁화 소스 가져옴 
        flower = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!flower.isPlaying && issong)        //조건문이 맞아서 바로 실행됨 
        {
            flower.Play();
            //issong = false;
        }
        else if (flower.isPlaying) issong = false;
        else if (!flower.isPlaying) StartCoroutine(CoolTime());

        Checkflower();
    }


    void Checkflower()  //무궁화 계속 플레잉 되고 있는지 체크
    {
        if (flower.isPlaying)
        {  
            canrun = true;   //재생중일 때 움직일 수 있음
        }
        else if (!flower.isPlaying)
        {
            canrun = false;  //재생 끝나면 움직이면 안됨           
        }
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(cooltime);
        issong = true;
    }
}

/* -------------------------------------------------------------------------------------------------------
스크립트 설명 - 무궁화 꽃이 게임 매니저

· 일단 Empty Obejct 에 들어가는 코드입니다.
· 이 코드의 역할은 음악 재생 및 플레이어가 움직일 수 있는 상황, 없는 상황을 판단해주는 static canrun을 관리합니다.
· 코루틴 CoolTime을 통해 무궁화가 언제 재생될지 조절해줍니다. 추후에 랜덤시간으로 변경하기??
 ----------------------------------------------------------------------------------------------------------*/
