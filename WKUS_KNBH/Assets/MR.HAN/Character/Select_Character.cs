using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Select_Character : MonoBehaviour
{
    public GameObject[] player_Character;   //������ �� �ִ� ĳ���� �迭 

    public static int number = 0;  //� ĳ���� �����ؾ����� ����

    public static Select_Character Instance;    //�̱��� ����

    public PhotonView PV;

    private void Awake()
    {     
        Instance = this;
    }

    //ó�� ���۰� ���ÿ� ĳ���� �Ҵ� 
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
