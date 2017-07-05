using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour {

	CameraRaycaster cameraRaycaster;
	public GameObject selectedObject { get; set;}

	void Start () {
		cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
	}

	// Update is called once per frame
	void Update () {
		// Checks for a unit under the cursor
		if (Input.GetMouseButtonDown (0)) {
			GameObject obj = cameraRaycaster.hit.collider.gameObject;
			selectObject (obj);
		}
	}


	/**
	 *  Queries the current raycast hit and assigns it to the selectedObject if it is a unit. 
	*/
	private void selectObject (GameObject obj) {
		if (obj.tag == "Static") {
			deselect ();
			selectedObject = obj;
			Statics statics = obj.GetComponent<Statics> ();
			statics.isSelected (true);
		}
	}

	private void deselect () {
		if (selectedObject) {
			if (selectedObject.tag == "Static") {
				Statics statics = selectedObject.GetComponent<Statics> ();
				statics.isSelected (false);
			}
		}
	}
}
