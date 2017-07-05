using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spotlight : MonoBehaviour {

	public GameObject bacteria;

	private Light lt;
	private float initialIntensity;
	//	private CameraRaycaster cameraRaycaster;

	void Awake () {
		lt = GetComponent<Light> ();
		initialIntensity = lt.intensity;
		StartCoroutine (spawnBacterias ());
	}

	// Use this for initialization
	void OnTriggerEnter (Collider coll) {
		if (coll.gameObject.name.Contains("RBC")) {
			Destroy (coll.gameObject);
			lt.intensity--;
		}
		if (lt.intensity == 0) {
			this.gameObject.SetActive(false);
			StopAllCoroutines ();
		}
	}
//
//	void OnGUI () {
//		if (selected) {
//			GUI.color = new Color (0.5f, 0.5f, 0.5f, 0.8f);
//			GUIText
//			GUI.Box (new Rect (0.0f, Screen.height * 0.6f, Screen.height * 0.1f, Screen.height * 0.1f), size() + "wound");
//		}
//	}

	private string size () {
		if (initialIntensity <= 20.0f)
			return "small";
		else if (initialIntensity <= 40.0f)
			return "medium";
		else if (initialIntensity <= 60.0f)
			return "large";
		else
			return "unknown";
	}

	IEnumerator spawnBacterias () {
		while (Var.infected == true) {
			yield return new WaitForSeconds (Random.Range (15, 20));
			Vector3 pos = new Vector3 (Random.Range (100, Screen.width-100), Random.Range (250, Screen.height-100), Camera.main.transform.position.y);
			Instantiate (bacteria, Camera.main.ScreenToWorldPoint (pos), Quaternion.identity);
		}
	}
}
