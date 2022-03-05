using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass_Trigger : MonoBehaviour
{
    public int count = 0;   //몇번 문제인지 알려주기 위한 변수

    public GameObject[] question;   //문항들 넣으면 됨

    public GameObject question_Pannel;  //질문 패널 (트리거 들어가면 ON 나가면 OFF)

    public static Glass_Trigger Instance;
    private void Awake()
    {
        Instance = this;
    }


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bridge_Quest")
        {
            question_Pannel.SetActive(true);
            question[count].SetActive(true);
            count += 1;
            Debug.Log("count");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        question_Pannel.SetActive(false);
        //출발지로 다시 이동한다는 선택지 의식해서 
        if (count == 0)
        {
            question[count].SetActive(false);
        }
        else
        {
            question[count - 1].SetActive(false);
        }
    }
}
