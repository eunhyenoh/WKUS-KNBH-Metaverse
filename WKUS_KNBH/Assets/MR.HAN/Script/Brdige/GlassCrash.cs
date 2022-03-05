using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassCrash : MonoBehaviour
{
    AudioSource Crash;
    // Start is called before the first frame update
    void Start()
    {
        Crash = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("소리재생");
        Crash.Play();
        Destroy(gameObject, 1f);
    }
}
