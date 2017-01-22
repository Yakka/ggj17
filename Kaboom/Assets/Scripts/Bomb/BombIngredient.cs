using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BombIngredient : MonoBehaviour {

    public IngredientData ingredientData;

    private int quantity;   //Total amount of this component (gameplay)
    private Dictionary<EffectType, IngredientData.Effect> effectsDictionary = new Dictionary<EffectType, IngredientData.Effect>();

    public void Start() {
        foreach(IngredientData.Effect effect in ingredientData.effectsList) {
            effectsDictionary.Add(effect.type, effect);
        }
    }

    public void SetGameplayQuantity(float _quantity) {
        quantity = Mathf.Clamp((int)_quantity, ingredientData.min, ingredientData.max);
    }

    public int GetGameplayQuantity() {
        return quantity;
    }

    public int GetFullQuantity() {
        return quantity * ingredientData.delta;
    }

    public int GetFinalEffectValue(EffectType _type) {
        int effectValue = 0;
        foreach (IngredientData.Effect effect in ingredientData.effectsList) {
            if(effect.type == _type) {
                int factor = effect.reversed ? -1 : 1;
                effectValue = effect.valuePerUnit * quantity * factor + effect.baseValue;
                break;
            }
        }
        return effectValue;
    }

    public List<EffectType> GetAllTypes() {
        return new List<EffectType>(effectsDictionary.Keys);
    }

    public int GetCost() {
        return GetGameplayQuantity() * ingredientData.moneyPerUnit;
    }

}
