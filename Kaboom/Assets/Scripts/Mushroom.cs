using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Mushroom : MonoBehaviour {
    private enum MushroomState {Counting = 0, Exploding, Length }
    private MushroomState state;
    private SpriteRenderer sprite;
    private Animator animator;
    private float timer;
    
    public void Start() {
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sprite.enabled = false;
        timer = 0f;
        state = MushroomState.Exploding;
    }

    public void Update() {
        timer += Time.deltaTime;
        if(timer > 2) {
            DisplayMushroom();
        }
    }

    public void DisplayMushroom() {
        sprite.enabled = true;
        animator.SetBool("IsLaunched", true);
    }

    public void SpecialEffects() {
        Camera.main.GetComponent<CameraShake>().Shake(5);
    }
}
