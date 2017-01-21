using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Mushroom : MonoBehaviour {
    private enum MushroomState {Counting = 0, Exploding, Length }
    private MushroomState state;
    private SpriteRenderer sprite;
    private float timer;
    
    public void Start() {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        timer = 0f;
        state = MushroomState.Exploding;
    }

    public void Update() {
        timer += Time.deltaTime;
        if(timer > 2) {
            Kaboom();
        }
    }

    public void Kaboom() {
        sprite.enabled = true;
    }
}
