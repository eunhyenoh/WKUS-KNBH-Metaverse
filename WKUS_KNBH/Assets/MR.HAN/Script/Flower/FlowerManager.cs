using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    public static bool canrun = false;  //�������� �� �� true, �����̸� �ȵ� �� false
    bool issong = true;   // false�� ���ǹ����� �ɷ����� �뷡��� �ȵ�.


    public float cooltime = 5;  // ���Ŀ� ��Ÿ�� �����ϰ� ���� 

    AudioSource flower; //����ȭ ���� �ҽ� 


    // Start is called before the first frame update
    void Start()
    {
        //����ȭ �ҽ� ������ 
        flower = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!flower.isPlaying && issong)        //���ǹ��� �¾Ƽ� �ٷ� ����� 
        {
            flower.Play();
            //issong = false;
        }
        else if (flower.isPlaying) issong = false;
        else if (!flower.isPlaying) StartCoroutine(CoolTime());

        Checkflower();
    }


    void Checkflower()  //����ȭ ��� �÷��� �ǰ� �ִ��� üũ
    {
        if (flower.isPlaying)
        {  
            canrun = true;   //������� �� ������ �� ����
        }
        else if (!flower.isPlaying)
        {
            canrun = false;  //��� ������ �����̸� �ȵ�           
        }
    }

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(cooltime);
        issong = true;
    }
}

/* -------------------------------------------------------------------------------------------------------
��ũ��Ʈ ���� - ����ȭ ���� ���� �Ŵ���

�� �ϴ� Empty Obejct �� ���� �ڵ��Դϴ�.
�� �� �ڵ��� ������ ���� ��� �� �÷��̾ ������ �� �ִ� ��Ȳ, ���� ��Ȳ�� �Ǵ����ִ� static canrun�� �����մϴ�.
�� �ڷ�ƾ CoolTime�� ���� ����ȭ�� ���� ������� �������ݴϴ�. ���Ŀ� �����ð����� �����ϱ�??
 ----------------------------------------------------------------------------------------------------------*/
