using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BonusPanel : MonoBehaviour {

    private Text moneyPanel;

    void Start() {
        moneyPanel = GetComponent<Text>();
    }

	void Update() {
        moneyPanel.text = "<color=#7F4040>Reward:</color> " + Gameloop.instance.missionDataList[Gameloop.instance.playerProgression].budget.ToString()+ "$";
    }
}
