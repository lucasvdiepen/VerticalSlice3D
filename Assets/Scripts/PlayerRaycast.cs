using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public GameObject player;//puntkomma
    [SerializeField] private float raycastLength;
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
