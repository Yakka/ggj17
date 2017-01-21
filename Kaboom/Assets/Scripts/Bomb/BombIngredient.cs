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
        int factor = effectsDictionary[_type].reversed ? -1 : 1;
        int effectValue = effectsDictionary[_type].valuePerUnit * quantity * factor + effectsDictionary[_type].baseValue;
        return effectValue;
    }

    public List<EffectType> GetAllTypes() {
        List<EffectType> typesList = new List<EffectType>();
        foreach(IngredientData.Effect effect in ingredientData.effectsList) {
            if(!typesList.Contains(effect.type)) {
                typesList.Add(effect.type);
            }
        }
        return typesList;
    }

    public int GetCost() {
        return GetGameplayQuantity() * ingredientData.moneyPerUnit;
    }

}
