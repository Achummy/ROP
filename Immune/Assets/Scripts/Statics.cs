using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statics : MonoBehaviour {

//	private CameraRaycaster cameraRaycaster;
	private Renderer selectedCircle;
	private bool selected;

	/**
	 * Initialize every stated variables by finding the GameObjects, setting values to false
	 * or instantiating empty datastructures
	 */
	void Start () {
//		cameraRaycaster = Camera.main.GetComponent<CameraRaycaster> ();

		selectedCircle = transform.GetChild (0).gameObject.GetComponent<Renderer> ();
		selectedCircle.enabled = false;
		selected = false;
	}

	void Update () {
	}
	// Update is called once per frame
	void FixedUpdate () {
	}

	public bool isSelected () {
		return selected;
	}

	public void isSelected (bool s) {
		selected = s;
		if (selected) {
			selectedCircle.enabled = true;
		} else {
			selectedCircle.enabled = false;	
		}
	}


}
