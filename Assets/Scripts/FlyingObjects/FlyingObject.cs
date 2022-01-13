using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    private Transform target;
    private Rigidbody rb;
    [SerializeField] private float initialAngle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

        ThrowObject2();
    }

    public void ThrowObject()
    {
        Vector3 p = target.position;

        float gravity = Physics.gravity.magnitude;
        float angle = initialAngle * Mathf.Deg2Rad;

        Vector3 targetPosition = new Vector3(p.x, 0, p.z);
        Vector3 thisPosition = new Vector3(transform.position.x, 0, transform.position.z);

        float distance = Vector3.Distance(targetPosition, thisPosition);
        float yOffset = transform.position.y - p.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * (Mathf.Sqrt((0.5f * gravity * Mathf.Pow(distance, 2))) / (distance * Mathf.Tan(angle) + yOffset));
        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        float angleBetweenObects = Vector3.Angle(Vector3.forward, targetPosition - thisPosition) * (p.x > transform.position.x ? 1 : -1);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObects, Vector3.up) * velocity;

        //rb.velocity = finalVelocity;
        rb.AddForce(finalVelocity * rb.mass, ForceMode.Impulse);
    }

    public void ThrowObject2()
    {
        Vector3 direction = target.position - transform.position;
        float height = direction.y;
        direction.y = 0;

        float distance = direction.magnitude;
        float radAngle = initialAngle * Mathf.Deg2Rad;

        direction.y = distance * Mathf.Tan(radAngle);
        distance += height / Mathf.Tan(radAngle);

        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * radAngle));
        rb.velocity = velocity * direction.normalized;
    }
}
