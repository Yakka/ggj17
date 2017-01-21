using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class BombIngredient : MonoBehaviour {
    [System.Serializable]
    public struct IngredientEffects {
        public int effect1;
        public int effect2;
    }

    public string name; //Name of the component (UI)
    public string unit; //Unit name (UI)
    public int delta;   //Amount of this component per quantity (UI)
    public int min;     //Minimum value (gameplay)
    public int max;     //Maximum value (gameplay)
    
    public IngredientEffects unitEffects;

    private int quantity;   //Total amount of this component (gameplay)

    public void SetGameplayQuantity(float _quantity) {
        quantity = Mathf.Clamp((int)_quantity, min, max);
    }

    public int GetGameplayQuantity() {
        return quantity;
    }

    public int GetFullQuantity() {
        return quantity * delta;
    }

    public IngredientEffects GetIngredientEffects() {
        IngredientEffects effects;
        effects.effect1 = unitEffects.effect1 * quantity;
        effects.effect2 = unitEffects.effect2 * quantity;
        return effects;
    }
}
