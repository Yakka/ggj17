using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScientistVoice : MonoBehaviour {

    private AudioSource source;

    void Start() {
        source = GetComponent<AudioSource>();
    }

	public void PlayVoice() {
        source.Play();
    }
}
