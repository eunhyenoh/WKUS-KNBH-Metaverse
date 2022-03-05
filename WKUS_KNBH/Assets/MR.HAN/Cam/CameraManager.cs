using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraManager : MonoBehaviour
{
    // 이녀석은 CameraRotation 프리팹안에 넣어주는 스크립트 입니다. 버튼은 PrimeManager에서 수정합니다.
    public GameObject[] camera_Point;

    public static CameraManager Instance;



    private void Awake()
    {
        Instance = this;
    }

    //카메라 변경할때 초기화 시키기위해서 선언 
    public void Off_CameraPoint()
    {

        for (int i = 0; i < camera_Point.Length; i++)
        {
            camera_Point[i].SetActive(false);
        }


    }

    public void On_CameraPoint(int i)
    {
        Off_CameraPoint();
        camera_Point[i].SetActive(true);
    }
}
