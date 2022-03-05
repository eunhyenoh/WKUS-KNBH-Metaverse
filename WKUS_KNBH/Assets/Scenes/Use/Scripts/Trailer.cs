using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trailer : MonoBehaviour
{

    //변경할 변수
    public float delay;
    public float Skip_delay;
    public int cnt;

    //타이핑효과 변수
    public string[] fulltext;

    public int dialog_cnt;
    string currentText;

    //타이핑확인 변수
    public bool text_exit;
    public bool text_full;
    public bool text_cut;


    // 여기서부터 수정
    public GameObject[] talk_image;
    public GameObject IdiconU;
    public GameObject trailer_Btn;
    private int count; // 대사 총 개수 

    //시작과 동시에 타이핑시작
    void Start()
    {
        Get_Typing(dialog_cnt, fulltext);
        count = fulltext.Length - 1;    //나와야 할 총 대사 가져옴 (-1한건 0부터 시작하니까 대사창 3개면 2로해줘야니까)
    }


    //모든 텍스트 호출완료시 탈출
    void Update()
    {
        if (cnt == 0)
        {
            gameObject.SetActive(true);

        }


        if (text_exit == true)
        {

        }
        if (Input.GetMouseButtonDown(0))    //좌클릭으로 대사 넘기는거 가능하게 
        {
            End_Typing();
            if (cnt == count)   //-1 해준거는 cnt는 0부터 시작하니까
            {              
                gameObject.SetActive(false);               
            }
            if (cnt == 3)   //여자 off, 남자 on
            {
                NextImage(1);
            }
            else if (cnt == 5) // 남자 off, 교수님 on
            {
                NextImage(2);
            }
            else if (cnt == 7) // 교수님 off, 눈반짝남자 on
            {

                NextImage(3);
            }
            else if (cnt == 8)  //남자 off, 교수님 on
            {
                NextImage(2);
                IdiconU.SetActive(true);
            }

        }
    }

    public void NextImage(int i)
    {
        for (int j = 0; j < talk_image.Length; j++)
        {
            talk_image[j].SetActive(false);
        }
        talk_image[i].SetActive(true);
    }

    //다음버튼함수
    public void End_Typing()
    {
        //다음 텍스트 호출
        if (text_full == true)
        {
            cnt++;
            text_full = false;
            text_cut = false;
            StartCoroutine(ShowText(fulltext));
        }
        //텍스트 타이핑 생략
        else
        {
            text_cut = true;
        }
    }

    //텍스트 시작호출
    public void Get_Typing(int _dialog_cnt, string[] _fullText)
    {
        //재사용을 위한 변수초기화
        text_exit = false;
        text_full = false;
        text_cut = false;
        cnt = 0;

        //변수 불러오기
        dialog_cnt = _dialog_cnt;
        fulltext = new string[dialog_cnt];
        fulltext = _fullText;

        //타이핑 코루틴시작
        StartCoroutine(ShowText(fulltext));
    }

    IEnumerator ShowText(string[] _fullText)
    {
        //모든텍스트 종료
        if (cnt >= dialog_cnt)
        {
            text_exit = true;
            StopCoroutine("showText");
        }
        else
        {
            //기존문구clear
            currentText = "";
            //타이핑 시작
            for (int i = 0; i < _fullText[cnt].Length; i++)
            {
                //타이핑중도탈출
                if (text_cut == true)
                {
                    break;
                }
                //단어하나씩출력
                currentText = _fullText[cnt].Substring(0, i + 1);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            //탈출시 모든 문자출력
            Debug.Log("Typing 종료");
            this.GetComponent<Text>().text = _fullText[cnt];
            yield return new WaitForSeconds(Skip_delay);

            //스킵_지연후 종료
            Debug.Log("Enter 대기");
            text_full = true;
        }
    }

    public void End_Trailer()
    {
        SceneManager.LoadScene(1);
    }
}
