using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameloop : MonoBehaviour {

    static public Gameloop instance = null;

	public enum GameState {
        BombMaking,
        BombTesting,
        Length
    };

    public GameState state = GameState.BombMaking;
    public int money = 100;
    public Canvas canvas;
    public Text moneyUI;
    public Bomb bomb;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Update() {
        moneyUI.text = "<color=#7F4040>Mission budget :</color> <size=36>" + money.ToString() + "$</size>";
    }

    public void NextGameState() {
        switch(state) {
            case GameState.BombMaking:
                state = GameState.BombTesting;
                money -= bomb.GetTotalCost();
                SceneManager.LoadScene(1);
                break;
            case GameState.BombTesting:
                state = GameState.BombMaking;
                SceneManager.LoadScene(0);
                break;
        }
    }

    
}
