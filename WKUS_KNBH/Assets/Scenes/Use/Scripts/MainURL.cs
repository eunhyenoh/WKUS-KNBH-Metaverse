using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainURL : MonoBehaviour
{
    [SerializeField] GameObject blink;

    public void Game_Disconnect()
    {
        Launcher.Instance.player_DisConnect();
    }
 public void URL()
    {
        Application.OpenURL("https://contents.wku.ac.kr/");
    }
    public void WaffleURL()
    {
        Application.OpenURL("https://waffle.wku.ac.kr/lms/login.jsp");
    }

    public void TakeAShot()
    {
        StartCoroutine("CaptureIt");
    }
    IEnumerator CaptureIt()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        string fileName = @"C:\Screenshot\test" + timeStamp + ".png";
        string pathToSave = fileName;
        ScreenCapture.CaptureScreenshot(pathToSave);
        yield return new WaitForEndOfFrame();
        Instantiate(blink, new Vector2(0f, 0f), Quaternion.identity);
    }
}
