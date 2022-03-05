using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickImage : MonoBehaviour
{
    public GameObject pannel;

    public void Open()
    {
        pannel.SetActive(true);
    }
    public void Close()
    {
        pannel.SetActive(false);
    }
}
