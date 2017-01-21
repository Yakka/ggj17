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
  

    public void Start() {
        bombIngredients.AddRange(GetComponentsInChildren<BombIngredient>());
    }
    
    public Dictionary<EffectType, int> GetAllFinalEffects() {
        Dictionary<EffectType, int> allEffects = new Dictionary<EffectType, int>();
        // Initialize dictionary
        for(int i = 0; i < (int)EffectType.Length; i++) {
            allEffects.Add((EffectType)i, 0);
        }
        // Add the real values of the dictionary
        foreach (BombIngredient bombIngredient in bombIngredients) {
            foreach(EffectType type in bombIngredient.GetAllTypes()) {
                allEffects[type] += bombIngredient.GetFinalEffectValue(type);
            }
        }

        for (int i = 0; i < (int)EffectType.Length; i++) {
            Debug.Log(allEffects[(EffectType)i]);
        }

        return allEffects;
    }

    public int GetTotalCost() {
        int value = 0;
        foreach(BombIngredient ingredient in bombIngredients) {
            value += ingredient.GetCost();
        }
        return value;
    }
}
