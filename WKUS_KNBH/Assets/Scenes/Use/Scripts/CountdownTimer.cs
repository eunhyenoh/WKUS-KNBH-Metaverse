using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;

public class CountdownTimer : MonoBehaviour
{
    public string levelToLad;
    //  private float timer = 10f;
    private float timer = 10f;
    private TMP_Text timerSeconds;

    void Start()
    {
        timerSeconds = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerSeconds.text = timer.ToString("f0");
        if (timer <= 0)
        {
             Application.LoadLevel(levelToLad);
         
        }
    }
}
