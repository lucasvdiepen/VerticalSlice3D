using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{   
    [SerializeField]private Transform target;
    [SerializeField]private Vector3 cameraOffset;
    [SerializeField]private float accelerationSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.transform.position + cameraOffset, accelerationSpeed * Time.deltaTime);
    }
}
