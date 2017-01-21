using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IngredientName", menuName = "Data/Ingredient", order = 1)]
public class IngredientData : ScriptableObject {

    public string name; //Name of the component (UI)
    public string unit; //Unit name (UI)
    public int delta;   //Amount of this component per quantity (UI)
    public int min;     //Minimum value (gameplay)
    public int max;     //Maximum value (gameplay)
    public int moneyPerUnit; //Dollars

    [System.Serializable]
    public struct Effect { public EffectType type; public int valuePerUnit; public bool reversed; public int baseValue; };
    public List<Effect> effectsList = new List<Effect>(); //Used to set the game data
}
