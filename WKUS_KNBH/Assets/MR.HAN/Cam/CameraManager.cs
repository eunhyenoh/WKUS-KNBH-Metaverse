using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraManager : MonoBehaviour
{
    // �̳༮�� CameraRotation �����վȿ� �־��ִ� ��ũ��Ʈ �Դϴ�. ��ư�� PrimeManager���� �����մϴ�.
    public GameObject[] camera_Point;

    public static CameraManager Instance;



    private void Awake()
    {
        Instance = this;
    }

    //ī�޶� �����Ҷ� �ʱ�ȭ ��Ű�����ؼ� ���� 
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
