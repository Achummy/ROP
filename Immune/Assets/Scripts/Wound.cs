using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wound : MonoBehaviour {

	public GameObject bacteria;
	public int size { get; set;}
	private Vector3 reduceSize;

	// Use this for initialization
	void Awake () {
		reduceSize = new Vector3 (0.0f, -0.10f, 0.0f);
		StartCoroutine (spawnbacteria ());
		size = 25;
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.name.Contains("RBC")) {
			Destroy (coll.gameObject);
			size--;
			transform.localScale += reduceSize;
		}
		if (size == 0) {
			this.gameObject.SetActive(false);
			StopAllCoroutines ();
		}
	}
	IEnumerator spawnbacteria () {
		while (Var.infected == true) {
			yield return new WaitForSeconds (Random.Range (15, 20));
			Vector3 pos = new Vector3 (Random.Range (100, Screen.width-100), Random.Range (250, Screen.height-100), Camera.main.transform.position.y);
			Instantiate (bacteria, Camera.main.ScreenToWorldPoint (pos), Quaternion.identity);
		}
	}
}
