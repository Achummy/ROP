using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour {

	// Use this for initialization
	public GameObject bacteria;
	public Queue<Transform> bacterias {get; set;}
	private GameObject macrophage;

	void Awake () {
		bacterias = new Queue<Transform> ();
		getChildObjects();
		StartCoroutine (multiply ());
	}

	void FixedUpdate () {
		onScreen ();
	}

	private void getChildObjects () {
		foreach (Transform child in transform) {
			if (child.gameObject.name.Contains("Bac")) {
				bacterias.Enqueue (child);
			}
		}
	}

	IEnumerator multiply () {
		while (true) {
			yield return new WaitForSeconds (Random.Range(17,20));
			if (macrophage == null) {
				Instantiate (bacteria, this.transform.position + Vector3.right*10 + Vector3.back*5, Quaternion.identity);
			}
		}
		
	}
		
	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.name.Contains("Macrophage") && macrophage==null) {
			if (coll.gameObject.GetComponent<Units> ().currentTarget == transform.position) {
				StopAllCoroutines ();
				StartCoroutine (destroyBacterias ());
				macrophage = coll.gameObject;
			}
		}
	}

	IEnumerator destroyBacterias () {
		while (true) {
			if (bacterias.Count == 0) {
				yield return new WaitForSeconds(0.5f);
				Destroy (macrophage);
				this.gameObject.SetActive(false);
			}
			yield return new WaitForSeconds (0.3f);
			Destroy (bacterias.Dequeue ().gameObject);
		}
	}

	void onScreen () {
		Vector3 screenPos = Camera.main.WorldToScreenPoint (this.transform.position);
		Vector3 newPos = new Vector3 (Mathf.Clamp (screenPos.x, 0.0f, Screen.width), Mathf.Clamp (screenPos.y, 250.0f, Screen.height), screenPos.z);
		if (screenPos != newPos) {
			Debug.Log ("It went through!");
			this.transform.position = Camera.main.ScreenToWorldPoint (newPos);
		}
	}

}
