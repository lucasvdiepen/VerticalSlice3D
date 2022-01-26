using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    private bool isDead = false;

    private void Update()
    {
        //Check if player fell off
        if (transform.position.y <= -5f) Dead();
    }

    public void CheckPlayerRaycast()
    {
        if (FindObjectOfType<PlayerRaycast>().RaycastHitPlayer()) Dead();
    }

    public void Dead()
    {
        if(!isDead)
        {
            isDead = true;

            FindObjectOfType<FadeOut>().Fade();
        }
    }
}
