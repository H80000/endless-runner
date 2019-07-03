using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float speed = 0;
	public static BackgroundScroller current;
	public Renderer rend;

	float position = 0;

	// Use this for initialization
	void Start () {
		current = this;
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		position += speed;
		if (position > 1.0f) {
			position -= 1.0f;
		}
		rend.material.mainTextureOffset = new Vector2(position, 0);
	}
}
