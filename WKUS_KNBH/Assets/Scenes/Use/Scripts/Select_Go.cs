using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_Go : MonoBehaviour
{
    public GameObject select_pannel; // 패널 고르는거 닫기 
    public GameObject[] wherego_canvas; //캔버스 2개 넣으면 됨 
    public GameObject select_primesquiz; //프라임, 오징어선택 넣으면 됨 
    public GameObject select_squiz;     //무궁화, 구름다리 선택 넣으면 됨

    public void Go_Prime()  //프라임 버튼 눌렀을 때
    {
        select_pannel.SetActive(false);
        wherego_canvas[0].SetActive(true);
        Launcher.what_Scene_Go = 2;
    }

    public void Go_Squiz() // 무궁화 버튼 눌렀을 때
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
        // 둘다 안켜져 있으면 선택하는 패널 On(방 나갔다가 다시 선택하러 들어왔을때 경우나 에러 등등)
        if (!wherego_canvas[0] && !wherego_canvas[1] && !wherego_canvas[2] && !select_squiz)
        {
            select_pannel.SetActive(true);
        }
    }

    //뒤로가기 버튼 때문에 넣어줌 전체 패널 닫고 뒤로 가기하면 나올 패널 On을 위한 빌드 
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

    //전체 패널 닫고 뒤로 가기하면 나올 패널 On ex) 무궁화,구름다리 패널에서 뒤로가기 눌렀을 시 프라임,오징어 선택 넣어주면 됨
    public void BackButton(GameObject on)
    {
        Off_Pannel();
        on.SetActive(true);
    }
}
