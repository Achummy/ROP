using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	CameraRaycaster cameraRaycaster;
	GameObject selectedUnit;

	// Use this for initialization
	void Start () {
		cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
	}
	
	// Update is called once per frame
	void Update () {

		// Checks for a unit under the cursor
		if (Input.GetMouseButton (0)) {
			selectUnit ();
		}

		// Moves the selected unit to the cursor
		if (Input.GetMouseButton (1) && selectedUnit != null && cameraRaycaster.layerHit != Layer.RaycastEndStop) {
			Units unit = selectedUnit.GetComponent<Units> ();
			unit.setTarget (cameraRaycaster.hit.point);
		}
	}

	/**
	 *  Queries the current raycast hit and assigns it to the selectedUnit 
	 *  if it is a unit. 
	*/
	void selectUnit () {
		GameObject temp = cameraRaycaster.hit.collider.gameObject;
		if (temp.tag == "Unit") {
			selectedUnit = temp;
		}
	}


}
