using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ReportGenerator : MonoBehaviour {

    public List<EffectData> effectDataList = new List<EffectData>();
    public Bomb bomb;
    private Text textUI;

    public void Start() {
        textUI = GetComponent<Text>();
    }

    private string GenerateReport() {
        Dictionary<EffectType, EffectScale> dictionary = bomb.GetAllFinalEffects();
        string report = string.Empty;
        foreach(EffectData data in effectDataList) {
            switch(dictionary[data.type]) {
                case EffectScale.None:
                    report += data.textNone + "\n";
                    break;
                case EffectScale.Big:
                    report += data.textBig + "\n";
                    break;
            }// TODO faire le small
        }
        return report;
    }

    public void UpdateReport() {
        textUI.text = GenerateReport();
    }
	
}
