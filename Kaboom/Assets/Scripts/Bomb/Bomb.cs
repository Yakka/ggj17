using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

    public List<BombIngredient> bombIngredients = new List<BombIngredient>();

    BombIngredient.IngredientEffects effects;

    public void Start() {
        bombIngredients.AddRange(GetComponentsInChildren<BombIngredient>());
        effects.effect1 = 0;
        effects.effect2 = 0;
    }
    
    public BombIngredient.IngredientEffects GetBombEffects() {
        BombIngredient.IngredientEffects effects;
        effects.effect1 = 0;
        effects.effect2 = 0;
        foreach(BombIngredient ingredient in bombIngredients) {
            BombIngredient.IngredientEffects ingredientEffects = ingredient.GetIngredientEffects();
            effects.effect1 += ingredientEffects.effect1;
            effects.effect2 += ingredientEffects.effect2;
        }
        return effects;
    }
}
