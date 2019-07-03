using UnityEngine;
using System.Collections;

public class pickupPoints : MonoBehaviour {

	private int interval = 3;

	public int scoreToGive;

	public Renderer rend;

	private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
		theScoreManager = FindObjectOfType<ScoreManager> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.name == "Player"){
			theScoreManager.AddScore (scoreToGive);
			GetComponent<AudioSource>().Play();
			rend.enabled = false;
		}
	}


}
