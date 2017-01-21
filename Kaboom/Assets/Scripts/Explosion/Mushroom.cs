using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Mushroom : MonoBehaviour {

    private AudioSource audioSource;
    
    public void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void SpecialEffects() {
        Camera.main.GetComponent<CameraShake>().Shake();
    }
    
    public void EndScene() {
        SceneManager.LoadScene("bombMaking");
    }
}
