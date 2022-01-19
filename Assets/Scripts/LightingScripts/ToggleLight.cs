using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    private bool colorState;
    private Color lightColor, newColor;
    [SerializeField] private float onSpeed, offSpeed;
    [SerializeField] private float blinkRate, blinkSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        newColor = new Color(0, 0, 0, 0);
        lightColor = gameObject.GetComponent<VLight>().colorTint;
    }
    private void StartLoop()
    {
        StartCoroutine(ToggleLighting(blinkSpeed));
    }
    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BlinkLight();
        }
        if (colorState)
        {
            lightColor = Color.Lerp(lightColor, newColor, onSpeed * Time.deltaTime);
        }
        else
        {
            lightColor = Color.Lerp(lightColor, newColor, offSpeed * Time.deltaTime);
        }
        gameObject.GetComponent<VLight>().colorTint = lightColor;
    }
    private IEnumerator ToggleLighting(float blinkSpeed)
    {
        for (int i = 0; i < 2; i++)
        {
            colorState = !colorState;
            if (colorState)
            {
                newColor = Color.white;
            }
            else
            {
                newColor = new Color(0, 0, 0, 0);
            }
            yield return new WaitForSeconds(blinkSpeed);
        }
    }
    public void BlinkLight()
    {
        StartLoop();
    }
}
