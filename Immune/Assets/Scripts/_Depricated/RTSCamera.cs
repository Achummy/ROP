//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class RTSCamera : MonoBehaviour {
//
//	private float cameraSpeed = 12.0f;
//	private float adjustSpeed = 5.0f;
//	private float offset = 3.5f;
//
//	private float[] mapLimits;
//
//	private bool locked = false;
//	private bool scrollLock = true;
//
//	private UnitSelection unitSelection;
//
//
//	// Use this for initialization
//	void Awake () {
//		Cursor.lockState = CursorLockMode.Confined;
//		unitSelection = Camera.main.GetComponent<UnitSelection> ();
//	}
//
//	void Start () {
//		if (mapLimits == null) {
//			mapLimits = new float[] {-1000.0f, 1000.0f, -1000.0f, 1000.0f};
//		}
//	}
//	
//	// Update is called once per frame
//	void LateUpdate () {
//		if (!locked) {
//			if (Input.GetKey(KeyCode.DownArrow)) {
//				this.transform.position += Vector3.down * Time.deltaTime * adjustSpeed;
//			} else if (Input.GetKey(KeyCode.UpArrow)) {
//				this.transform.position += Vector3.up * Time.deltaTime * adjustSpeed;
//			}
//			if (Input.GetKey (KeyCode.Minus)) {
//				this.transform.Rotate (Vector3.left * Time.deltaTime * adjustSpeed);
//			} else if (Input.GetKey (KeyCode.Equals)) {
//				this.transform.Rotate (Vector3.right * Time.deltaTime * adjustSpeed);
//			}
//			if (!scrollLock) {
//				if (Input.GetAxis ("Mouse ScrollWheel") > 0f) {
//					this.transform.position += Vector3.down * Time.deltaTime * adjustSpeed * 2;
//				} else if (Input.GetAxis ("Mouse ScrollWheel") < 0f) {
//					this.transform.position += Vector3.up * Time.deltaTime * adjustSpeed * 2;
//				}
//			}
//
//			if (Input.GetKey (KeyCode.Space)) {
//				focusSelected ();
//			}
//			moveCamera ();
//
//		}
//		if (Input.GetMouseButtonDown (0))
//			locked = true;
//		if (Input.GetMouseButtonUp (0))
//			locked = false;
//	}
//
//
//	void moveCamera () {
//		
//		Vector3 mousePos = Input.mousePosition;
//
//		if (mousePos.y <= 5.0f) {
//			this.transform.position += Vector3.back * Time.deltaTime * cameraSpeed;
//		} else if (mousePos.y >= (Screen.height - 5.0f)) {
//			this.transform.position += Vector3.forward * Time.deltaTime * cameraSpeed;
//		}
//		if (mousePos.x <= 5.0f) {
//			this.transform.position += Vector3.left * Time.deltaTime * cameraSpeed;
//		} else if (mousePos.x >= (Screen.width - 5.0f)) {
//			this.transform.position += Vector3.right * Time.deltaTime * cameraSpeed;
//		}
//
//		clamp ();
//	}
//
//	void focusSelected () {
//		ArrayList objects = unitSelection.selectedObject;
//		if (objects.Count != 0) {
//			float x_pos = 0.0f;
//			float z_pos = 0.0f;
//			foreach (GameObject obj in objects) {
//				x_pos += obj.transform.position.x;
//				z_pos += obj.transform.position.z;
//			}
//			this.transform.position = new Vector3 (x_pos/objects.Count, transform.position.y, z_pos/objects.Count - offset);
//		}
//
//		clamp ();
//	}
//
//	void clamp () {
//		this.transform.position = new Vector3 (Mathf.Clamp(transform.position.x, mapLimits[0], mapLimits[1]), 
//			Mathf.Clamp(transform.position.y, -3.0f, 2.0f), Mathf.Clamp(transform.position.z, mapLimits[2], mapLimits[3]));
//	}
//
//	public void setMapLimits (float xmin, float xmax, float zmin, float zmax) {
//		mapLimits = new float[] {xmin, xmax, zmin, zmax};
//	}
//
//	public void setScrollLock (bool value) {
//		scrollLock = value;
//	}
//}
