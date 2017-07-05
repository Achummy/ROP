using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplacementTarget : MonoBehaviour {

	public int count;

	Renderer outer;
	Renderer middle;
	Renderer inner;
	Renderer closer;
	Renderer point;

	// Use this for initialization
	void Start () {
		outer = transform.GetChild (0).gameObject.GetComponent<Renderer> ();
		middle = transform.GetChild (1).gameObject.GetComponent<Renderer> ();
		inner = transform.GetChild (2).gameObject.GetComponent<Renderer> ();
		closer = transform.GetChild (3).gameObject.GetComponent<Renderer> ();
		point = transform.GetChild (4).gameObject.GetComponent<Renderer> ();
		StartCoroutine (changeColor ());
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator changeColor () {
		while (true) {
			outer.enabled = true;
			yield return new WaitForSeconds (0.1f);
			outer.enabled = false;
			middle.enabled = true;
			yield return new WaitForSeconds (0.1f);
			middle.enabled = false;
			inner.enabled = true;
			yield return new WaitForSeconds (0.1f);
			inner.enabled = false;
			closer.enabled = true;
			yield return new WaitForSeconds (0.1f);
			closer.enabled = false;
			point.enabled = true;
			yield return new WaitForSeconds (0.1f);
			point.enabled = false;
		}
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.name.Contains("RBC")) {
			Destroy (coll.gameObject);
			count--;
		}
		if (count == 0) {
			this.gameObject.SetActive(false);
		}
	}

}
