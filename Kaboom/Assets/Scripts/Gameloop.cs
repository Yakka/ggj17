using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameloop : MonoBehaviour {

    static public Gameloop instance = null;

	public enum GameState {
        BombMaking,
        BombTesting,
        MissionReport,
        Length
    };

    public GameState state = GameState.BombMaking;
    public int money = 100;
    public Bomb bomb;
    public List<MissionData> missionDataList = new List<MissionData>();
    private int playerProgression = 0;
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
                if(IsMissionAccomplished()) {
                    state = GameState.MissionReport;
                } else {
                    state = GameState.BombMaking;
                }
                SceneManager.LoadScene(0);
                break;
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
