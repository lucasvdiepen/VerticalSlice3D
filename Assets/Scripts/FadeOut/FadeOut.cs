using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    private Animator fadeAnim;
    [SerializeField] private float timer;
    [SerializeField] private string sceneName;

    private void Start()
    {
        fadeAnim = gameObject.GetComponent<Animator>();
    }
    public void Fade() 
    {
        fadeAnim.SetTrigger("fade");
        Invoke("FadeOutAnimation", timer);
    }
    public void FadeOutAnimation() 
    {
        fadeAnim.SetTrigger("fadeOut");
    }
    public void ResetScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}