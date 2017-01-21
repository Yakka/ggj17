using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BombIngredient : MonoBehaviour {

    public IngredientData ingredientData;

    private int quantity;   //Total amount of this component (gameplay)
    private Dictionary<EffectType, int> effectsDictionary = new Dictionary<EffectType, int>();

    public void Start() {
        foreach(IngredientData.Effect effect in ingredientData.effectsList) {
            effectsDictionary.Add(effect.type, effect.valuePerUnit);
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
        int effectValue = effectsDictionary[_type] * quantity;
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
