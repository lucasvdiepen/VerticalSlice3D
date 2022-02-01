using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//>>DE MESH COLLIDER TELT NIET, LET OP<<
//Gebruik een box collider of iets voor muren

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private float raycastLength;

    public bool RaycastHitPlayer()
    {
        Debug.Log("Raycast hit function");

        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10);

        if (Physics.Raycast(ray, out RaycastHit hitData, raycastLength))
        {
            Debug.Log(hitData.collider.tag);
            return hitData.collider.CompareTag("Player");
        }
        return false;
    }
}
