using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ReportGenerator : MonoBehaviour {

    public Bomb bomb;
    private Text textUI;

    public void Start() {
        textUI = GetComponent<Text>();
    }

    private string GenerateReport() {
        Dictionary<EffectType, int> allEffects = bomb.GetAllFinalEffects();
        string report = string.Empty;
        foreach(EffectData data in Bomb.instance.effectDataList) {
            // Scale: big
            if(allEffects[data.type] > data.valueBig) {
                report += data.textBig + "\n";
            }
            // Scale: small
            else if(allEffects[data.type] > data.valueSmall) {
                report += data.textSmall + "\n";
            }
            // scale: none
            else {
                report += data.textNone + "\n";
            }
        }
        return report;
    }

    public void UpdateReport() {
        textUI.text = GenerateReport();
    }
	
}
