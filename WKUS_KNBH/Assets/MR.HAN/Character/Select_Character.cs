using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Select_Character : MonoBehaviour
{
    public GameObject[] player_Character;   //선택할 수 있는 캐릭터 배열 

    public static int number = 0;  //어떤 캐릭터 선택해야할지 변수

    public static Select_Character Instance;    //싱글톤 선언

    public PhotonView PV;

    private void Awake()
    {     
        Instance = this;
    }

    //처음 시작과 동시에 캐릭터 할당 
    private void Start()
    {
        PV = GetComponent<PhotonView>();
        if(PV.IsMine)
        {
            //Character_Select();
        }

    }
    public void Character_Select()
    {
        player_Character[number].SetActive(true);
    }
}
