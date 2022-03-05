using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass_Trigger : MonoBehaviour
{
    public int count = 0;   //��� �������� �˷��ֱ� ���� ����

    public GameObject[] question;   //���׵� ������ ��

    public GameObject question_Pannel;  //���� �г� (Ʈ���� ���� ON ������ OFF)

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
        //������� �ٽ� �̵��Ѵٴ� ������ �ǽ��ؼ� 
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
