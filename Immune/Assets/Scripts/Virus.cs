using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour {

	public GameObject virus;
	public static bool recognized { get; set;}
	public GameObject macrophage;

	// Use this for initialization
	void Awake () {
		recognized = false;
	}
	void Start () {
		StartCoroutine (infect ());
	}
	
	// Update is called once per frame
	void Update () {
		onScreen ();
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.GetComponent<Units> ().currentTarget == transform.position) {
			if (coll.gameObject.name.Contains ("HTCell") && !recognized && macrophage != null) {
				Units tcell = coll.gameObject.GetComponent<Units> ();
				tcell.addTarget (tcell.initialPos);
				recognized = true;
			} else if (recognized && coll.gameObject.name.Contains ("KTCell")) {
				if (macrophage != null) macrophage.SetActive (false);
				this.gameObject.SetActive (false);
			} else if (coll.gameObject.name.Contains ("Macrophage") && macrophage == null) {
				if (coll.gameObject.GetComponent<Units> ().currentTarget == transform.position) {
					macrophage = coll.gameObject;
				}
			}			
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

	IEnumerator infect () {
		while (Var.infected) {
			yield return new WaitForSeconds (Random.Range(30,40));
			if (macrophage == null) {
				Vector3 pos = Camera.main.ScreenToWorldPoint (
					              new Vector3 (Random.Range (100, Screen.width - 100), Random.Range (300, Screen.height - 100), Camera.main.WorldToScreenPoint (this.transform.position).z));
				this.transform.SetPositionAndRotation (pos, Quaternion.identity);
			} else {
				StopAllCoroutines ();
			}
		}

	}
}
