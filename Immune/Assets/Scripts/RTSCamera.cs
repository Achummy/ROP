using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour {

	private float cameraSpeed = 11.0f;
	// Use this for initialization
	void Awake () {
		Cursor.lockState = CursorLockMode.Confined;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		moveCamera ();
	}

	void moveCamera () {
		
		Vector3 mousePos = Input.mousePosition;

		if (mousePos.y <= 15.0f) {
			this.transform.position += Vector3.back * Time.deltaTime * cameraSpeed;
		} else if (mousePos.y >= (Screen.height - 15.0f)) {
			this.transform.position += Vector3.forward * Time.deltaTime * cameraSpeed;
		}
		if (mousePos.x <= 15.0f) {
			this.transform.position += Vector3.left * Time.deltaTime * cameraSpeed;
		} else if (mousePos.x >= (Screen.width - 15.0f)) {
			this.transform.position += Vector3.right * Time.deltaTime * cameraSpeed;
		}
	}
}
