using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    [SerializeField]private Transform target;
    [SerializeField]private Vector3 cameraOffset;
    [SerializeField]private float accelerationSpeed;
    
    // Update is called once per frame
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + cameraOffset, accelerationSpeed * Time.deltaTime);
    }
}
