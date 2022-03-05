using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(DateTime.Now.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string GetCurrentDate()
    {
        return DateTime.Now.ToString(("HH:mm:ss tt"));

    }
    public void ChangeSky()
    { 

    }


}

