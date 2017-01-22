using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    AudioSource source;

    public AudioClip paper;
    public AudioClip hey;

    void Start() {
        source = GetComponent<AudioSource>();
    }

    public void PlayPaper() {
        source.clip = paper;
        source.Play();
    }

    public void PlayHey() {
        source.clip = hey;
        source.Play();
    }

}
