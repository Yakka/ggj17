using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void Stater() {
        if(Gameloop.instance != null) {
            Gameloop.instance.NextGameState();
        }
        SceneManager.LoadScene(3);
    }
}
