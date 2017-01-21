using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MoneyPanel : MonoBehaviour {

    private Text moneyPanel;

    void Start() {
        moneyPanel = GetComponent<Text>();
    }

	void Update() {
        moneyPanel.text = "<color=#7F4040>Mission budget :</color> <size=36>" + Gameloop.instance.money.ToString() + "$</size>";
    }
}
