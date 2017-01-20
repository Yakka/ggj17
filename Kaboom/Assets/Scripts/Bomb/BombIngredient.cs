using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombIngredient : MonoBehaviour {
    public string name; //Name of the component (UI)
    public string unit; //Unit name (UI)
    public int delta;   //Amount of this component per quantity (UI)
    public int min;     //Minimum value (gameplay)
    public int max;     //Maximum value (gameplay)

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
}
