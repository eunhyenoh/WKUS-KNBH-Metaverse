using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_LightManager : MonoBehaviour
{
    public GameObject Light;
    //public GameObject sunLight;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Dayandnignt.Instance.isNight)
        {
            Light.SetActive(true);
        }
        else
        {
            Light.SetActive(false);
        }
    }
}
