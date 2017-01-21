using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Flash : MonoBehaviour {

    private bool isFlashing = false;
    private Image image;
    public int periodInMiniseconds = 500;
    public float timer;

    public void Start() {
        image = GetComponent<Image>();
        isFlashing = true;
    }

    /*public void Update() {
        timer -= Time.deltaTime;
        if(timer < 0f) {
            StopFlash();
        }
        if(isFlashing) {
            if((Time.time * 1000) % periodInMiniseconds < periodInMiniseconds / 2) {
                image.enabled = false;
            } else {
                image.enabled = true;
            }
        }
    }*/

    public void LaunchFlash() {
        isFlashing = true;
    }

    public void StopFlash() {
        isFlashing = false;
        image.enabled = false;
    }

}
