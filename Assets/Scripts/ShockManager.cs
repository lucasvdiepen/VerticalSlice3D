using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockManager : MonoBehaviour
{
    [SerializeField] private float timeBetweenShocks = 5f;
    [SerializeField] private float timeBetweenLightningAndShock = 1f;

    private float lastShockTime = 0f;
    private bool shockDone = false;

    public IEnumerator Shock()
    {
        FindObjectOfType<ToggleLight>().BlinkLight();

        yield return new WaitForSeconds(timeBetweenLightningAndShock);

        FindObjectOfType<CameraShake>().StartShake();
        FindObjectOfType<FlyingObjectsSpawner>().SpawnObjects();

        FindObjectOfType<PlayerDeath>().CheckPlayerRaycast();

        FindObjectOfType<CraneController>().DoCraneAnimation();

        Lamp[] lamps = FindObjectsOfType<Lamp>();
        foreach (Lamp lamp in lamps) lamp.BlinkLight();

        lastShockTime = Time.time;
        shockDone = false;
    }

    public void StartShock()
    {
        StartCoroutine(Shock());
    }

    private void Update()
    {
        /*if (Time.time >= (lastShockTime + timeBetweenShocks) && !shockDone)
        {
            shockDone = true;
            StartShock();
        }*/
    }
}
