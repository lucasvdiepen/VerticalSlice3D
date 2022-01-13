using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxVelocity = 10f;
    public float speed = 1f;
    private bool isGrounded;
    private bool onSlope;
    public float jumpFactor = 6f;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (other.gameObject.tag == "Slope")
        {
            onSlope = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
        if (other.gameObject.tag == "Slope")
        {
            onSlope = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (Input.GetKey(KeyCode.A) && !onSlope)
            rb.AddForce(Vector3.left * speed);
        if (Input.GetKey(KeyCode.D) && !onSlope)
            rb.AddForce(Vector3.right * speed);
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
