using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("프라임매니저 트리거 진입확인했습니다.");
        if (other.tag == "PrimeIn")
        {
            NewLauncher.Instance.GoScene(8);    //프라임관In대기방 넣어주기           
        }
        else if (other.tag == "Go_Prime")
        {
            NewLauncher.Instance.GoScene(7);
        }
        else if (other.tag == "Hall_Portal")
        {
            NewLauncher.Instance.GoScene(9);
        }
        else if (other.tag == "Go_Bridge")
        {
            NewLauncher.Instance.GoScene(10);
        }
        else if (other.tag == "Go_GameCapture")
        {
            gameObject.transform.position = new Vector3(-9.5f, 24f, 16f);
        }
        else if (other.tag == "Go_MotionCapture")
        {
            gameObject.transform.position = new Vector3(112f, 24f, -8f);
        }
        else if (other.tag == "GoComeBack_3F")
        {
            gameObject.transform.position = new Vector3(-96f, 9f, 5f);
        }
        else if (other.tag == "Go_elevator3F")
        {
            gameObject.transform.position = new Vector3(50f, 7f, -23f);
        }
        else if(other.tag =="Go_elevator1F")
        {
            gameObject.transform.position = new Vector3(45f, -5f, -23f);
        }
    }
}
