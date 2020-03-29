using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            anim.SetBool("Touched", true);
        
    }
    private void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Up"))
            anim.SetBool("Touched", false);
    }
}
