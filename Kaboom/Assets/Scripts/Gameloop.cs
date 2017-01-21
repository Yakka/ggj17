using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gameloop : MonoBehaviour {

	public enum GameState {
        BombMaking,
        BombTesting,
        Report
    };

    public GameState state = GameState.BombMaking;
    public int money = 100;
    public Text moneyUI;
    public Bomb bomb;

    public void Update() {
        moneyUI.text = money.ToString()+"$";
    }

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

    public void LaunchBomb() {
        money -= bomb.GetTotalCost();
    }
}
