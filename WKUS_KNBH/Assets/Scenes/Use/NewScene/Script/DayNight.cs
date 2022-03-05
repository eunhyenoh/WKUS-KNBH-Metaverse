using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField]
    private Transform lookPoint;
    [SerializeField]
    private float rotateSpeed = 12f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(lookPoint.position, Vector3.right, rotateSpeed * Time.deltaTime);
        transform.LookAt(lookPoint, Vector3.right);
        if (gameObject.transform.rotation.x <= -180)
        {

        }
        else if (gameObject.transform.rotation.x >= 20)
        {

        }
    }
}
