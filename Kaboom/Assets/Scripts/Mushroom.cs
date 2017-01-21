using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Mushroom : MonoBehaviour {
    private SpriteRenderer sprite;

    public void Start() {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    public void Kaboom() {
        sprite.enabled = true;
    }
}
