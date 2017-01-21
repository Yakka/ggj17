using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public List<BombIngredient> bombIngredients = new List<BombIngredient>();
    

    public void Start() {
        bombIngredients.AddRange(GetComponentsInChildren<BombIngredient>());
    }
    
    public Dictionary<EffectType, int> GetAllFinalEffects() {
        Dictionary<EffectType, int> allEffects = new Dictionary<EffectType, int>();
        // Initialize dictionary
        foreach(EffectType type in Enum.GetValues(typeof(EffectType)).Cast<EffectType>()) {
            allEffects.Add(type, 0);
        }
        // Add the real values of the dictionary
        foreach (BombIngredient bombIngredient in bombIngredients) {
            foreach(EffectType type in bombIngredient.GetAllTypes()) {
                allEffects[type] += bombIngredient.GetFinalEffectValue(type);
            }
        }
        
        return allEffects;
    }

    public void debug() {
        Debug.Log(GetAllFinalEffects()[EffectType.Radiance]);
    }
}
