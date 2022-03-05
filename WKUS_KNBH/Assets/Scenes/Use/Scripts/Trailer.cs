using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Trailer : MonoBehaviour
{

    //������ ����
    public float delay;
    public float Skip_delay;
    public int cnt;

    //Ÿ����ȿ�� ����
    public string[] fulltext;

    public int dialog_cnt;
    string currentText;

    //Ÿ����Ȯ�� ����
    public bool text_exit;
    public bool text_full;
    public bool text_cut;


    // ���⼭���� ����
    public GameObject[] talk_image;
    public GameObject IdiconU;
    public GameObject trailer_Btn;
    private int count; // ��� �� ���� 

    //���۰� ���ÿ� Ÿ���ν���
    void Start()
    {
        Get_Typing(dialog_cnt, fulltext);
        count = fulltext.Length - 1;    //���;� �� �� ��� ������ (-1�Ѱ� 0���� �����ϴϱ� ���â 3���� 2������ߴϱ�)
    }


    //��� �ؽ�Ʈ ȣ��Ϸ�� Ż��
    void Update()
    {
        if (cnt == 0)
        {
            gameObject.SetActive(true);

        }


        if (text_exit == true)
        {

        }
        if (Input.GetMouseButtonDown(0))    //��Ŭ������ ��� �ѱ�°� �����ϰ� 
        {
            End_Typing();
            if (cnt == count)   //-1 ���ذŴ� cnt�� 0���� �����ϴϱ�
            {              
                gameObject.SetActive(false);               
            }
            if (cnt == 3)   //���� off, ���� on
            {
                NextImage(1);
            }
            else if (cnt == 5) // ���� off, ������ on
            {
                NextImage(2);
            }
            else if (cnt == 7) // ������ off, ����¦���� on
            {

                NextImage(3);
            }
            else if (cnt == 8)  //���� off, ������ on
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

    //������ư�Լ�
    public void End_Typing()
    {
        //���� �ؽ�Ʈ ȣ��
        if (text_full == true)
        {
            cnt++;
            text_full = false;
            text_cut = false;
            StartCoroutine(ShowText(fulltext));
        }
        //�ؽ�Ʈ Ÿ���� ����
        else
        {
            text_cut = true;
        }
    }

    //�ؽ�Ʈ ����ȣ��
    public void Get_Typing(int _dialog_cnt, string[] _fullText)
    {
        //������ ���� �����ʱ�ȭ
        text_exit = false;
        text_full = false;
        text_cut = false;
        cnt = 0;

        //���� �ҷ�����
        dialog_cnt = _dialog_cnt;
        fulltext = new string[dialog_cnt];
        fulltext = _fullText;

        //Ÿ���� �ڷ�ƾ����
        StartCoroutine(ShowText(fulltext));
    }

    IEnumerator ShowText(string[] _fullText)
    {
        //����ؽ�Ʈ ����
        if (cnt >= dialog_cnt)
        {
            text_exit = true;
            StopCoroutine("showText");
        }
        else
        {
            //��������clear
            currentText = "";
            //Ÿ���� ����
            for (int i = 0; i < _fullText[cnt].Length; i++)
            {
                //Ÿ�����ߵ�Ż��
                if (text_cut == true)
                {
                    break;
                }
                //�ܾ��ϳ������
                currentText = _fullText[cnt].Substring(0, i + 1);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            //Ż��� ��� �������
            Debug.Log("Typing ����");
            this.GetComponent<Text>().text = _fullText[cnt];
            yield return new WaitForSeconds(Skip_delay);

            //��ŵ_������ ����
            Debug.Log("Enter ���");
            text_full = true;
        }
    }

    public void End_Trailer()
    {
        SceneManager.LoadScene(1);
    }
}
