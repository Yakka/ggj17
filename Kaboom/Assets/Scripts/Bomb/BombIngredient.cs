using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum EffectType {
    Radiance,
    Deflagration
}

public class BombIngredient : MonoBehaviour {

    public string name; //Name of the component (UI)
    public string unit; //Unit name (UI)
    public int delta;   //Amount of this component per quantity (UI)
    public int min;     //Minimum value (gameplay)
    public int max;     //Maximum value (gameplay)
    public int moneyPerUnit; //Dollars
    private int quantity;   //Total amount of this component (gameplay)

    [System.Serializable]
    public struct Effect { public EffectType type; public int valuePerUnit; };
    public List<Effect> effectsList = new List<Effect>(); //Used to set the game data

    private Dictionary<EffectType, int> effectsDictionary = new Dictionary<EffectType, int>();

    public void Start() {
        foreach(Effect effect in effectsList) {
            effectsDictionary.Add(effect.type, effect.valuePerUnit);
        }
    }

    public void SetGameplayQuantity(float _quantity) {
        quantity = Mathf.Clamp((int)_quantity, min, max);
    }

    public int GetGameplayQuantity() {
        return quantity;
    }

    public int GetFullQuantity() {
        return quantity * delta;
    }

    public int GetFinalEffectValue(EffectType _type) {
        return effectsDictionary[_type] *= quantity;
    }

    public List<EffectType> GetAllTypes() {
        List<EffectType> typesList = new List<EffectType>();
        foreach(Effect effect in effectsList) {
            if(!typesList.Contains(effect.type)) {
                typesList.Add(effect.type);
            }
        }
        return typesList;
    }

    public int GetCost() {
        return GetGameplayQuantity() * moneyPerUnit;
    }

}
