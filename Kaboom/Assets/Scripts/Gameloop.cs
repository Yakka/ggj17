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
    public Bomb bomb;
    private float timer = 0f;
    private bool isChangingState = false;

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Update() {
        if(isChangingState) {
            if (timer > 0f) {
                timer -= Time.deltaTime;
            } else {
                isChangingState = false;
                SceneManager.LoadScene(1);
            }
        }
        
    }

    public void NextGameState() {
        switch(state) {
            case GameState.BombMaking:
                state = GameState.BombTesting;
                money -= bomb.GetTotalCost();
                timer = 0.5f;
                isChangingState = true;
                break;
            case GameState.BombTesting:
                state = GameState.BombMaking;
                SceneManager.LoadScene(0);
                break;
        }
    }

    
}
