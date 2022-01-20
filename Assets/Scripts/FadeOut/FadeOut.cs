using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    private Animator fadeAnim;
    [SerializeField] private float timer;

    private void Start()
    {
        fadeAnim = gameObject.GetComponent<Animator>();
    }

    public void Fade() 
    {
        fadeAnim.SetTrigger("Fade");
        Invoke("FadeOutAnimation", timer);
    }

    //Called by animation keyframe
    public void FadeOutAnimation() 
    {
        fadeAnim.SetTrigger("FadeOut");
    }

    //Called by animation keyframe
    public void ResetScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}