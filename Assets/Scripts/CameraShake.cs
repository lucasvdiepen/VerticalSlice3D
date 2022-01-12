using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float duration = 0.1f;
    [SerializeField] private float magnitude = 0.1f;

    public IEnumerator Shake()
    {
        Vector3 pos = transform.localPosition;
        float timeElapsed = 0;
        while(timeElapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, pos.z);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = pos;
    }

    private void Update()
    {
        //For testing
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Shake());
        }
    }
}
