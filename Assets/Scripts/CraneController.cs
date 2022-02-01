using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraneController : MonoBehaviour
{
    private Animator animator;
    private bool isCraneDown = false;
    [SerializeField] private AudioManager craneUp, craneDown;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void CraneUp()
    {
        animator.SetTrigger("CraneUp");
        isCraneDown = false;
    }

    private void CraneDown()
    {
        animator.SetTrigger("CraneDown");
        isCraneDown = true;
    }

    public void DoCraneAnimation()
    {
        if (isCraneDown) CraneUp();
        else CraneDown();
    }

    //Called by animation event
    public void StartShakeEvent()
    {
        FindObjectOfType<ShockManager>().StartShock();
    }
    public void PulseRaySoundUp() 
    {
        craneUp.Play("pulseray");
    }
    public void PulseRaySoundDown() 
    {
        craneDown.Play("pulseray");
    }
}
