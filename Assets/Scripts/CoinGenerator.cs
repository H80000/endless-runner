using UnityEngine;
using System.Collections;

public class CoinGenerator : MonoBehaviour {
	
	public ObjectPooler coinPool;

	public float distanceBetweenCoins;

	public void SpawnCoins(Vector3 startPosition){

		GameObject coin1 = coinPool.GetPooledObject ();
		coin1.transform.position = startPosition;
		coin1.SetActive (true);
		coin1.GetComponent<Renderer> ().enabled = true;

		GameObject coin2 = coinPool.GetPooledObject ();
		coin2.transform.position = new Vector3 (startPosition.x - distanceBetweenCoins, startPosition.y, startPosition.z);
		coin2.SetActive (true);
		coin2.GetComponent<Renderer> ().enabled = true;

		GameObject coin3 = coinPool.GetPooledObject ();
		coin3.transform.position = new Vector3 (startPosition.x + distanceBetweenCoins, startPosition.y, startPosition.z);
		coin3.SetActive (true);
		coin3.GetComponent<Renderer> ().enabled = true;

	}

}
