using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    private Animator fadeAnim;
    [SerializeField] private string sceneName;
    // Start is called before the first frame update
    private void Start()
    {
        fadeAnim = gameObject.GetComponent<Animator>();
    }
    public void ResetScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Fade() 
    {
        fadeAnim.SetTrigger("Fade");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Fade();
        }
    }
}
