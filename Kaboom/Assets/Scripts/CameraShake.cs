using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    private float timer = 0f;
    private float intensity;
    private const float defaultIntensity = 0.1f;
    private const float defaultTime = 0.5f;
    private bool isShaking = false;
	public float intensityFriction = 0f;
    private bool hasShaked = false;
	// Update is called once per frame
	void Update () {
        if(isShaking) {
            timer -= Time.deltaTime;
            if (timer > 0f) {
                if(hasShaked) {
                    hasShaked = false;
                    Camera.main.transform.position = Vector3.back * 10;
                } else {
                    Camera.main.transform.Translate(Random.Range(-intensity, intensity), Random.Range(-intensity, intensity), 0f);
                    hasShaked = true;
                }
            }
            else {
                Camera.main.transform.position = Vector3.back * 10;
                isShaking = false;
            }
            intensity = Mathf.Lerp(intensity, 0f, intensityFriction);
        }
	}

    public void Shake(float _time) {
        timer = _time;
        intensity = defaultIntensity;
        isShaking = true;
    }

    public void Shake(float _time, float _intensity = defaultIntensity) {
        timer = _time;
        intensity = _intensity;
        isShaking = true;
    }

    public void InfiniteShake(float _intensity = defaultIntensity) {
        timer = float.PositiveInfinity;
        intensity = _intensity;
        isShaking = true;
    }

    public void StopShake() {
        isShaking = false;
    }
}
