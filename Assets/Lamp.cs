using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    private bool lampState;
    [SerializeField] private GameObject lamp;
    [SerializeField] private Material onMat, offMat;
    [SerializeField] private Renderer lampRend;
   
    //call this function once at a time to blink lamp
    public void BlinkLight() 
    {
        StartCoroutine(Blink());
    }

    //turn off lamp, wait a (random) bit and blink light 1, 2 or 3 times. 
    private IEnumerator Blink() 
    {
        lampRend.material = offMat;
        lamp.SetActive(false);
        yield return new WaitForSeconds(Random.Range(1f, 1.5f));
        for (int i = 0; i < Random.Range(1, 4); i++) 
        {
            lampState = !lampState;
            lamp.SetActive(lampState);

            if (lampState) lampRend.material = onMat; 
            else lampRend.material = offMat; 

            yield return new WaitForSeconds(Random.Range(.1f, .3f));
        }
        lampRend.material = onMat;
        lamp.SetActive(true);
    }
}
