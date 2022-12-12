using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChamber : MonoBehaviour
{
    Animator animator;
    public bool opened;

    private void Start()
    {
        animator = GetComponent<Animator>();
        opened = false;
    }

    public void Open()
    {
        if (opened == false)
        {
            opened = true;
            animator.SetBool("Open", true);
        }
        else
        {
            opened=false;
            animator.SetBool("Open", false);
        }
    }
}
