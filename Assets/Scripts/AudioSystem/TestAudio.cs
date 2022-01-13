using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour
{
    [SerializeField] private string audioFileName;

    private void Start() {
        gameObject.GetComponent<AudioManager>().Play(audioFileName);
    }
}
