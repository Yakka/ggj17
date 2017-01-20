using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(UnityEngine.UI.Slider))]
public class IngredientSlider : MonoBehaviour {

    public BombIngredient bombIngredient;

    private Slider slider;

    public void Start() {
        slider = GetComponent<Slider>();
        if(bombIngredient != null) {
            slider.minValue = bombIngredient.min;
            slider.maxValue = bombIngredient.max;
        } else {
            Debug.LogError("Error: bombIngredient null reference. This slider is not linked to a bomb ingredient.");
        }
    }

    public void UpdateIngredientData() {
        bombIngredient.SetGameplayQuantity(slider.value);
    }
}
