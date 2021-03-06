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
        int value = 20;
        foreach(BombIngredient ingredient in bombIngredients) {
            value += ingredient.GetCost();
        }
        return value;
    }

    public string GetEffectReport(EffectType _type, EffectScale _scale) {
        foreach(EffectData effect in effectDataList) {
            if(effect.type == _type) {
                switch(_scale) {
                    case EffectScale.None:
                        return effect.textNone + "\n";
                    case EffectScale.Small:
                        return effect.textSmall + "\n";
                    case EffectScale.Big:
                        return effect.textBig+"\n";
                    default:
                        return "No text found.\n";
                }
            }
        }
        return "No text found.\n";
    }

    public Color GetColor() {
        float intensity = 0f;
        Color color = new Color(0, 0, 0);

        foreach(BombIngredient ingredient in Bomb.instance.bombIngredients) {
            float quantity = ingredient.GetGameplayQuantity() * 0.5f;
            intensity += quantity;

            switch(ingredient.ingredientData.name)
            {
                case "Hydrogen" : //Blue
                    color.b = Mathf.Min(color.b + quantity, 1f);
                break;
                case "Uranium" : //Green
                    color.g = Mathf.Min(color.g + quantity, 1f);
                break;
                case "Weight" : //Red
                    color.r = Mathf.Min(color.r + quantity, 1f);
                break;
                case "Altitude" : //Yellow
                    color.r = Mathf.Min(color.r + quantity * 0.5f, 1f);
                    color.g = Mathf.Min(color.g + quantity * 0.5f, 1f);
                break;
            }
        }

/*
        float H;
        float S;
        float V;

        Color.RGBToHSV(color, out H, out S, out V);

        S = Mathf.Min(intensity * 0.5f, 1f);
        V = Mathf.Min(intensity * 0.5f, 1f);

        return Color.HSVToRGB(H, S, V);
*/

        float min = 0.25f;
        intensity = Mathf.Clamp(intensity * 0.5f, 0f, 1f);
        color.b = Mathf.Min(color.b * intensity + min, 1f);
        color.g = Mathf.Min(color.g * intensity + min, 1f);
        color.r = Mathf.Min(color.r * intensity + min, 1f);

        return color;
    }
}
