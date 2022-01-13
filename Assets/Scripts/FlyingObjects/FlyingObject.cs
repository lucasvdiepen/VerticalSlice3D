using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ThrowObject(Vector3 target, float initialAngle)
    {
        Vector3 direction = target - transform.position;
        float height = direction.y;
        direction.y = 0;

        float distance = direction.magnitude;
        float radAngle = initialAngle * Mathf.Deg2Rad;

        direction.y = distance * Mathf.Tan(radAngle);
        distance += height / Mathf.Tan(radAngle);

        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * radAngle));
        rb.velocity = velocity * direction.normalized;

        Destroy(gameObject, 5f);
    }
}
