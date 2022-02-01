using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform root;
    [SerializeField] private bool isWalking;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private float maxVelocity = 10f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpFactor = 6f;
    [SerializeField] private float rotationSpeed = 2f;
    private bool isGrounded;
    private bool onSlope;
    private float goToRotation = 0f;
    [SerializeField] private Animator animator;

    private void Awake() {
        InvokeRepeating("WalkFootSteps", 0, .5f);
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            audioManager.Play("landing");
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
        bool isMoving = false;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.A) && !onSlope) 
        {
            rb.AddForce(Vector3.left * speed);
            isWalking = true;
            goToRotation = 0f;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.D) && !onSlope) 
        {
            rb.AddForce(Vector3.right * speed);
            isWalking = true;
            goToRotation = -180f;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * speed);
            goToRotation = -270f;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * speed);
            goToRotation = -90f;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * speed * jumpFactor);
            animator.SetTrigger("Jump");
        }

        if (Input.GetKeyUp(KeyCode.A)) isWalking = false;
        else if (Input.GetKeyUp(KeyCode.D)) isWalking = false;
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) isWalking = false;

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) goToRotation = -315f;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D)) goToRotation = -225f;
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)) goToRotation = -135f;
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A)) goToRotation = -45f;

        if (onSlope == true)
        {
            rb.AddForce(new Vector3(1, 0, 0));
            goToRotation = -180;
        }

        if (Input.GetKey(KeyCode.Return)) animator.SetTrigger("Slide");

        root.rotation = Quaternion.RotateTowards(root.rotation, Quaternion.Euler(new Vector3(0, goToRotation, 0)), Time.deltaTime * rotationSpeed);

        animator.SetBool("isRunning", isMoving);
    }

    private void WalkFootSteps() 
    {
        if (!isWalking) return;
              
        if(isGrounded) audioManager.Play("footstep");
    }
}
