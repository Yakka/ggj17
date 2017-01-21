using UnityEngine;

public class MouseParallax : MonoBehaviour {

    public float scale = 2f;
	Vector3 position;

	void Start () {
		position = transform.position;
	}

	void Update () {
		float mouseX = (Input.mousePosition.x / Screen.width - 0.5f) * -scale * 0.1f;
		float mouseY = (Input.mousePosition.y / Screen.width - 0.5f) * -scale * 0.1f;
		transform.position = position + new Vector3(mouseX, mouseY, 0f);
	}
}
