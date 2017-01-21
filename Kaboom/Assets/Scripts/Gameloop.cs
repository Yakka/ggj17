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
    public Canvas canvas;
    public Text moneyUI;
    public Bomb bomb;

    public void Update() {
        moneyUI.text = "<color=#7F4040>Mission budget :</color> <size=36>" + money.ToString() + "$</size>";
    }

    public void NextGameState() {
        switch(state) {
            case GameState.BombMaking:
                state = GameState.BombTesting;
                money -= bomb.GetTotalCost();
                canvas.enabled = false;
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
