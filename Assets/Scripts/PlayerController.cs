using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 10f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpFactor = 6f;
    private bool isGrounded;
    private bool onSlope;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (other.gameObject.CompareTag("Slope"))
        {
            onSlope = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if (other.gameObject.CompareTag("Slope"))
        {
            onSlope = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A) && !onSlope)
            rb.AddForce(new Vector3(-1.75f, 0, 0) * speed);
        if (Input.GetKey(KeyCode.D) && !onSlope)
            rb.AddForce(new Vector3(1.75f,0,0) * speed);
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(Vector3.forward * speed);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(Vector3.back * speed);
        if (Input.GetKey(KeyCode.Space) && isGrounded)
            rb.AddForce(Vector3.up * speed * jumpFactor);


        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }

        if (onSlope == true)
        {
            rb.AddForce(new Vector3(1, 0, 0));
        }
    }
}
