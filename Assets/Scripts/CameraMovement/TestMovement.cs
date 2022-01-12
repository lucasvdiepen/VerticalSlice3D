using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 movement;
    [SerializeField]private float moveSpeed;

    private void Awake() 
    {
        rb = gameObject.GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(rb.position += movement * moveSpeed * Time.fixedDeltaTime);
    }
}
