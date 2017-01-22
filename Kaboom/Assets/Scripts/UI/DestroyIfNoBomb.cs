using UnityEngine;

public class DestroyIfNoBomb : MonoBehaviour {

	public bool destroyIfNoBomb = false;

	void Start () {
		bool noBomb = true;
		foreach(BombIngredient ingredient in Bomb.instance.bombIngredients){
			if(ingredient.GetGameplayQuantity() != 0f)
				noBomb = false;
		}

		if(destroyIfNoBomb == noBomb)
			Destroy(gameObject);
	}
}
