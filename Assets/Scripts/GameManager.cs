using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public PlayerController thePlayer;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	private ScoreManager theScoreManager;

	public Transform musicPrefab;

	// Use this for initialization
	void Start () {
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		theScoreManager = FindObjectOfType<ScoreManager> ();

		if (!GameObject.FindGameObjectWithTag ("MM")) {
			Instantiate (musicPrefab, transform.position, Quaternion.identity);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame(){
		StartCoroutine ("RestartGameCo");
	}

	public IEnumerator RestartGameCo(){

		theScoreManager.scoreIncreasing = false;

		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds (0.6f);

		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		}

		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}
}
