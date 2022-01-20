using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenShocks = 5f;

    private float lastShockTime = 0f;

    public void Shock()
    {
        lastShockTime = Time.time;

        FindObjectOfType<ToggleLight>().BlinkLight();
        FindObjectOfType<CameraShake>().StartShake();
        FindObjectOfType<FlyingObjectsSpawner>().SpawnObjects();
    }

    private void Update()
    {
        if (Time.time >= (lastShockTime + timeBetweenShocks))
        {
            Shock();
        }
    }
}
