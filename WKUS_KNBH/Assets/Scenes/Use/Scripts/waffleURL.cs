using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waffleURL : MonoBehaviour
{
    private void OnTirggerEnter(Collider other)
    {
        Application.OpenURL("https://waffle.wku.ac.kr/lms/login.jsp");
    }
}
