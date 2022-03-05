using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampArea : MonoBehaviour
{
    public int what_number_Stamp;

    public static StampArea instance;

    public void Awake()
    {
        instance = this;
        int number = what_number_Stamp;
    }


    private void OnTriggerEnter(Collider other)
    {
        // 일정 투명도 이상 올라가면 반복 안되게 
        if(PrimeManager.Instance.stamp_Image[what_number_Stamp].color.a <=0.7 )
        {
            PrimeManager.Instance.check_stamp.SetActive(true);
            PrimeManager.Instance.FadeIn(what_number_Stamp);
        }
    }

}
