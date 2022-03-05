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
            twoDragon.transform.rotation = Quaternion.Euler(-90, 0, 0);    // �뷡�ϴ� ���̸� ������ ����
        }
        else if (!flower.isPlaying)
        {
           // twoDragon.transform.position = new Vector3(18, 5, 70);
            twoDragon.transform.rotation = Quaternion.Euler(-90, 180, 0); // �뷡 ������ �ٶ󺸰� ���� 
        }
    }
}

/* -------------------------------------------------------------------------------
��ũ��Ʈ ���� - ����ȭ ���� ����

�� ��ũ��Ʈ�� ����(����)���� �־��ִ� ��ũ��Ʈ�Դϴ�.

������ ����Ǹ� �ڵ����ְ� ������ ������ y rotation�� 180�� ���ư��ϴ�. (�ִϸ��̼����� ��ȭ���ѵ� ��������)

 --------------------------------------------------------------------------------*/
