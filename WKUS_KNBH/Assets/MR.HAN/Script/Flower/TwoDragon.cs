using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDragon : MonoBehaviour
{
    public AudioSource flower;

    private GameObject twoDragon;
    // Start is called before the first frame update
    void Start()
    {
        twoDragon = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (flower.isPlaying)
        {
           // twoDragon.transform.position = new Vector3(18, 5, 70);
            twoDragon.transform.rotation = Quaternion.Euler(-90, 0, 0);    // 노래하는 중이면 등지고 있음
        }
        else if (!flower.isPlaying)
        {
           // twoDragon.transform.position = new Vector3(18, 5, 70);
            twoDragon.transform.rotation = Quaternion.Euler(-90, 180, 0); // 노래 끝나면 바라보고 있음 
        }
    }
}

/* -------------------------------------------------------------------------------
스크립트 설명 - 무궁화 꽃이 용희

이 스크립트는 용희(술래)한테 넣어주는 스크립트입니다.

음악이 재생되면 뒤돌아있고 음악이 끝나면 y rotation이 180도 돌아갑니다. (애니메이션으로 변화시켜도 괜찮을듯)

 --------------------------------------------------------------------------------*/
