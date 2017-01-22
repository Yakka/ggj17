using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EffectType {
    Deads = 0,
    Radioactivity,
    Area,
    Destruction,
    Length
}

public enum EffectScale {
    None = 0,
    Small,
    Big,
    Length
}

public class Bomb : MonoBehaviour {

    public List<BombIngredient> bombIngredients = new List<BombIngredient>();
    public List<EffectData> effectDataList = new List<EffectData>();
    static public Bomb instance = null;
  

    void Awake() {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        bombIngredients.AddRange(GetComponentsInChildren<BombIngredient>());
        Debug.Log("p");
    }
    
    public Dictionary<EffectType, int> GetAllFinalEffects() {
        Dictionary<EffectType, int> allEffects = new Dictionary<EffectType, int>();
        // Initialize dictionary
        for(int i = 0; i < (int)EffectType.Length; i++) {
            allEffects.Add((EffectType)i, 0);
        }
        // Add the real values of the dictionary
        foreach (BombIngredient bombIngredient in GetComponentsInChildren<BombIngredient>()) {
            foreach(EffectType type in bombIngredient.GetAllTypes()) {
                allEffects[type] += bombIngredient.GetFinalEffectValue(type);
            }
        }

        return allEffects;
    }

    public Dictionary<EffectType, EffectScale> GetAllFinalEffectsAndScales() {
        Dictionary<EffectType, EffectScale> allFinalEffectsScales = new Dictionary<EffectType, EffectScale>();
        Dictionary<EffectType, int> allFinalEffects = GetAllFinalEffects();
        
        foreach (EffectData data in effectDataList) {
            // Scale: big
            if (allFinalEffects[data.type] >= data.valueBig) {
                allFinalEffectsScales[data.type] = EffectScale.Big;
            }
            // Scale: small
            else if (allFinalEffects[data.type] >= data.valueSmall) {
                allFinalEffectsScales[data.type] = EffectScale.Small;
            }
            // scale: none
            else {
                allFinalEffectsScales[data.type] = EffectScale.None;
            }
        }

        return allFinalEffectsScales;
    }

    public int GetTotalCost() {
        int value = 0;
        foreach(BombIngredient ingredient in bombIngredients) {
            value += ingredient.GetCost();
        }
        return value;
    }
}
