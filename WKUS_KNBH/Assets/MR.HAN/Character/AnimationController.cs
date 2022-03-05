using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        anim.SetTrigger("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jump");
        }
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", verticalInput);      //¾ÕµÚ °È´Â°Å
        anim.SetFloat("SideSpeed", horizontalInput);    //ÁÂ¿ì °È´Â°Å 
    }

    
}
