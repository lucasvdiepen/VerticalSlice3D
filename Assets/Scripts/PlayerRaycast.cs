using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//>>DE MESH COLLIDER TELT NIET, LET OP<<
//Gebruik een box collider of iets voor muren

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private float raycastLength;//puntkomma
    RaycastHit hitData;

    public bool RaycastHitPlayer()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 10);
        Vector3 hitPosition = hitData.point;

        if (Physics.Raycast(ray, out hitData, raycastLength))
        {            
            return hitData.collider.CompareTag("Player");
        }
        return false;
    }
}
