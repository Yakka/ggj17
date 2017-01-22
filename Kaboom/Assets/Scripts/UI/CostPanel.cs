using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CostPanel : MonoBehaviour {

    private Text costPanel;

    public void Start() {
        costPanel = GetComponent<Text>();
        costPanel.text = GeneratePanelText(Bomb.instance.GetTotalCost());
    }

    public void UpdateCost() {
        costPanel.text = GeneratePanelText(Bomb.instance.GetTotalCost());
    }

    private string GeneratePanelText(int cost) {
        return cost + "m$";
    }
}
