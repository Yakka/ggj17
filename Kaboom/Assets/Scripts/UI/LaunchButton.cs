using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LaunchButton : MonoBehaviour {

    private Button button;
    
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => LaunchButtonClick());
	}

    void Destroy() {
        button.onClick.RemoveListener(() => Gameloop.instance.NextGameState());
    }

    void LaunchButtonClick() {
        Dictionary<EffectType, EffectScale> effects = Bomb.instance.GetAllFinalEffectsAndScales();
        for (int i = 0; i < effects.Keys.Count; i++) {
            Gameloop.instance.report += Bomb.instance.GetEffectReport((EffectType)i, effects[(EffectType)i]);
        }
        Gameloop.instance.NextGameState();
    }

}
