using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum EffectType {
    Deads,
    Radioactivity,
    Area,
    LifeTime
}

public enum EffectScale {
    None,
    Small,
    Big
}

public class Bomb : MonoBehaviour {

    public List<BombIngredient> bombIngredients = new List<BombIngredient>();
    

    public void Start() {
        bombIngredients.AddRange(GetComponentsInChildren<BombIngredient>());
    }
    
    public Dictionary<EffectType, EffectScale> GetAllFinalEffects() {
        Dictionary<EffectType, int> allEffects = new Dictionary<EffectType, int>();
        Dictionary<EffectType, EffectScale> allEffectsScales = new Dictionary<EffectType, EffectScale>();
        // Initialize dictionary
        foreach (EffectType type in Enum.GetValues(typeof(EffectType)).Cast<EffectType>()) {
            allEffects.Add(type, 0);
        }
        // Add the real values of the dictionary
        foreach (BombIngredient bombIngredient in bombIngredients) {
            foreach(EffectType type in bombIngredient.GetAllTypes()) {
                allEffects[type] += bombIngredient.GetFinalEffectValue(type);
            }
        }

        foreach (EffectType type in Enum.GetValues(typeof(EffectType)).Cast<EffectType>()) {
            // TODO: add small effects
            if(allEffects[type] == 0) {
                allEffectsScales[type] = EffectScale.None;
            } else {
                allEffectsScales[type] = EffectScale.Big;
            }

        }

        return allEffectsScales;
    }

    public int GetTotalCost() {
        int value = 0;
        foreach(BombIngredient ingredient in bombIngredients) {
            value += ingredient.GetCost();
        }
        return value;
    }
}
