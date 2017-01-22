using UnityEngine;

public class ColorBomb : MonoBehaviour {

    new private SpriteRenderer renderer;
    
    public void Start() {
        renderer = GetComponent<SpriteRenderer>();
    }

	public void UpdateColor(){
		Color color = Bomb.instance.GetColor();
        renderer.color = color;
	}
}