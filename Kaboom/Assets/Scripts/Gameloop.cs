using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameloop : MonoBehaviour {

	public enum GameState {
        BombMaking,
        BombTesting,
        Report
    };

    public GameState state = GameState.BombMaking;

    public void NextGameState() {
        switch(state) {
            case GameState.BombMaking:
                state = GameState.BombTesting;
                break;
            case GameState.BombTesting:
                state = GameState.Report;
                break;
            case GameState.Report:
                state = GameState.BombMaking;
                break;
        }
    }
}
