using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CraneUP()
    {
        animator.SetTrigger("");
    }

    public void CraneDown()
    {

    }
}
