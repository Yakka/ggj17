using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class CostPanel : MonoBehaviour {

    public Bomb bomb;

    private Text costPanel;

    public void Start() {
        costPanel = GetComponent<Text>();
        costPanel.text = GeneratePanelText(bomb.GetTotalCost());
    }

    public void UpdateCost() {
        costPanel.text = GeneratePanelText(bomb.GetTotalCost());
    }

    private string GeneratePanelText(int cost) {
        return cost + "$";
    }
}
