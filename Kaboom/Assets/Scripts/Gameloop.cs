using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameloop : MonoBehaviour {

    static public Gameloop instance = null;

	public enum GameState {
        BombMaking = 0,
        BombTesting,
        Reporting,
        Winning,
        GameOver,
        Length
    };

    public GameState state = GameState.BombMaking;
    public int money = 100;
    public Bomb bomb;
    public List<MissionData> missionDataList = new List<MissionData>();
    public int playerProgression = 0;
    private float timer = 0f;
    private bool isChangingState = false;
    public bool firstBomb = true;
    public string report = string.Empty;

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
        if(Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        else if(Input.anyKey) {
            if(state == GameState.Reporting || state == GameState.Winning || state == GameState.GameOver || state == GameState.BombTesting) {
                NextGameState();
            }
        }
    }

    public void RestartGame() {
        money = 100;
        playerProgression = 0;
        firstBomb = true;
        report = string.Empty;
        foreach(BombIngredient ingredient in bomb.bombIngredients) {
            ingredient.SetGameplayQuantity(0);
        }
        SceneManager.LoadScene(0);
}

    public void NextGameState() {
        if(!isChangingState) {
            switch(state) {
                case GameState.BombMaking:
                    state = GameState.BombTesting;
                    money -= bomb.GetTotalCost();
                    timer = 0.5f;
                    isChangingState = true;
                    break;
                case GameState.BombTesting:
                    report = string.Empty;
                    firstBomb = false;
                    if (IsMissionAccomplished()) {
                        playerProgression++;
                        if (playerProgression >= missionDataList.Count) {
                            state = GameState.Winning;
                            SceneManager.LoadScene(5);
                        }
                        else {
                            money += missionDataList[playerProgression].budget;
                            if (money <= 0) {
                                state = GameState.GameOver;
                                SceneManager.LoadScene(2);
                            }
                            else {
                                state = GameState.BombMaking;
                                SceneManager.LoadScene(3);
                            }
                        }
                    }
                    else {
                        if (money <= 0) {
                            state = GameState.GameOver;
                            SceneManager.LoadScene(2);
                        }
                        else {
                            state = GameState.BombMaking;
                            SceneManager.LoadScene(3);
                        }
                    }
                    break;
                case GameState.Reporting:
                    
                    break;
                case GameState.Winning:
                    state = GameState.BombMaking;
                    RestartGame();
                    break;
                case GameState.GameOver:
                    state = GameState.BombMaking;
                    RestartGame();
                    break;
            }
        }
    }

    public bool IsMissionAccomplished() {
        bool accomplished = true;
        Dictionary<EffectType, EffectScale> effectsScale = bomb.GetAllFinalEffectsAndScales();
        foreach (MissionData.Goal goal in missionDataList[playerProgression].goals) {
            if (effectsScale[goal.type] != goal.scale) {
                accomplished = false;
            }
        }
        return accomplished;
    }
}
