using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LaunchButton : MonoBehaviour {

    private Button button;
    
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => LaunchButtonClick());
	}

    void Destroy() {
        button.onClick.RemoveListener(() => Gameloop.instance.NextGameState());
    }

    void LaunchButtonClick() {
        Gameloop.instance.NextGameState();
    }

}
