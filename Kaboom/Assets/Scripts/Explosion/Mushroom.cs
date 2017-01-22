using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class Mushroom : MonoBehaviour {

    private AudioSource audioSource;
    new private SpriteRenderer renderer;
    
    public void Start() {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        renderer = GetComponent<SpriteRenderer>();
        renderer.color = Bomb.instance.GetColor();
    }

    public void SpecialEffects() {
        Camera.main.GetComponent<CameraShake>().InfiniteShake();
    }
    
    public void EndScene() {
        Gameloop.instance.NextGameState();
    }
}
