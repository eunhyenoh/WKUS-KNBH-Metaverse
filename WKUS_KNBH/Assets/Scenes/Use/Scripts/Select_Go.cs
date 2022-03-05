using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Go : MonoBehaviour
{
    public GameObject select_pannel; // �г� ���°� �ݱ� 
    public GameObject[] wherego_canvas; //ĵ���� 2�� ������ �� 
    public GameObject select_primesquiz; //������, ��¡��� ������ �� 
    public GameObject select_squiz;     //����ȭ, �����ٸ� ���� ������ ��

    public void Go_Prime()  //������ ��ư ������ ��
    {
        select_pannel.SetActive(false);
        wherego_canvas[0].SetActive(true);
        Launcher.what_Scene_Go = 2;
    }

    public void Go_Squiz() // ����ȭ ��ư ������ ��
    {
        select_primesquiz.SetActive(false);
        select_squiz.SetActive(true);
        /*
        select_pannel.SetActive(false);
        wherego_canvas[1].SetActive(true);
        */
    }

    public void Go_FlowerCanvas()
    {
        select_squiz.SetActive(false);
        wherego_canvas[1].SetActive(true);
        Launcher.what_Scene_Go = 4;
    }

    public void Go_BridgeCanvas()
    {
        select_squiz.SetActive(false);
        wherego_canvas[2].SetActive(true);
        Launcher.what_Scene_Go = 3;
    }

    private void Update()
    {
        // �Ѵ� ������ ������ �����ϴ� �г� On(�� �����ٰ� �ٽ� �����Ϸ� �������� ��쳪 ���� ���)
        if (!wherego_canvas[0] && !wherego_canvas[1] && !wherego_canvas[2] && !select_squiz)
        {
            select_pannel.SetActive(true);
        }
    }

    //�ڷΰ��� ��ư ������ �־��� ��ü �г� �ݰ� �ڷ� �����ϸ� ���� �г� On�� ���� ���� 
    public void Off_Pannel()
    {
        select_pannel.SetActive(false);
        select_primesquiz.SetActive(false);
        select_squiz.SetActive(false);
        for(int i =0; i<wherego_canvas.Length;i++)
        {
            wherego_canvas[i].SetActive(false);
        }
    }

    //��ü �г� �ݰ� �ڷ� �����ϸ� ���� �г� On ex) ����ȭ,�����ٸ� �гο��� �ڷΰ��� ������ �� ������,��¡�� ���� �־��ָ� ��
    public void BackButton(GameObject on)
    {
        Off_Pannel();
        on.SetActive(true);
    }
}
