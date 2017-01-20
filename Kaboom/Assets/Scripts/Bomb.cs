using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    [System.Serializable]
    public class BombIngredient {
        public string name; //Name of the component (UI)
        public string unit; //Unit name (UI)
        public int delta;   //Amount of this component per quantity (UI)
        public int min;     //Minimum value (gameplay)
        public int max;     //Maximum value (gameplay)
        

        private int quantity;   //Total amount of this component (gameplay)

        public void SetQuantity(int _quantity) {
            quantity = Mathf.Clamp(_quantity, min, max);
        }

        public int GetGameplayQuantity() {
            return quantity;
        }

        public int GetQuantity() {
            return quantity * delta;
        }
    }

    public List<BombIngredient> ingredients = new List<BombIngredient>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
