using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour {

	// Use this for initialization
	public GameObject bact;
	public Queue<Transform> bacteria {get; set;}
	private GameObject macrophage;

	void Awake () {
		bacteria = new Queue<Transform> ();
		getChildObjects();
		StartCoroutine (multiply ());
	}

	void FixedUpdate () {
		onScreen ();
	}

	private void getChildObjects () {
		foreach (Transform child in transform) {
			if (child.gameObject.name.Contains("Bac")) {
				bacteria.Enqueue (child);
			}
		}
	}

	IEnumerator multiply () {
		while (true) {
			yield return new WaitForSeconds (Random.Range(17,20));
			if (macrophage == null) {
				Instantiate (bact, this.transform.position + Vector3.right*10 + Vector3.back*5, Quaternion.identity);
			}
		}
		
	}
		
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.name.Contains("Macrophage") && macrophage==null) {
			if (coll.gameObject.GetComponent<Units> ().currentTarget == transform.position) {
				StopAllCoroutines ();
				StartCoroutine (destroybacteria ());
				macrophage = coll.gameObject;
			}
		}
	}

	IEnumerator destroybacteria () {
		while (true) {
			if (bacteria.Count == 0) {
				yield return new WaitForSeconds(0.5f);
				Destroy (macrophage);
				this.gameObject.SetActive(false);
			}
			yield return new WaitForSeconds (0.3f);
			Destroy (bacteria.Dequeue ().gameObject);
		}
	}

	void onScreen () {
		Vector3 screenPos = Camera.main.WorldToScreenPoint (this.transform.position);
		Vector3 newPos = new Vector3 (Mathf.Clamp (screenPos.x, 0.0f, Screen.width), Mathf.Clamp (screenPos.y, 250.0f, Screen.height), screenPos.z);
		if (screenPos != newPos) {
			this.transform.position = Camera.main.ScreenToWorldPoint (newPos);
		}
	}

}
