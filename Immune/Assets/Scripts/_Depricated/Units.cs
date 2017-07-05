using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour {
//
//	public GameObject targetCircle;
	public Vector3 initialTarget = Vector3.zero;
//
//	private CameraRaycaster cameraRaycaster;
	private Rigidbody rb;
//	private Renderer selectedCircle;
//	private bool selected;
//
//	private Queue<GameObject> targetCircles;
//	private Queue<Vector3> targetPos;
	public Vector3 currentTarget {get; set;}
	public Vector3 initialPos { get; set;}
//	private GameObject currentCircle;
//
	private float speed;
//
	/**
	 * Initialize every stated variables by finding the GameObjects, setting values to false
	 * or instantiating empty datastructures
	 */
	void Awake () {
		addTarget(initialTarget);
		initialPos = transform.position;
	}
	void Start () {
//		cameraRaycaster = Camera.main.GetComponent<CameraRaycaster> ();
		rb = GetComponent<Rigidbody> ();

//		selectedCircle = transform.GetChild (1).gameObject.GetComponent<Renderer> ();
//		selectedCircle.enabled = false;
//		selected = false;
//
//		targetCircles = new Queue<GameObject> ();
//		targetPos = new Queue<Vector3> ();

		speed = 8f;
	}
//	void Update () {
//		// Moves the selected unit to the cursor
//
//		if (Input.GetMouseButtonDown (1) && selected) {
//			this.addTarget (cameraRaycaster.hit.point);
//		}
//	}

	void FixedUpdate () {
		move ();
	}
//
//	public bool isSelected () {
//		return selected;
//	}
//
//	public void isSelected (bool s) {
//		selected = s;
//		if (selected) {
//			selectedCircle.enabled = true;
//		} else {
//			selectedCircle.enabled = false;	
//		}
//	}
//
	public void addTarget (Vector3 pos) {
		pos = pos - new Vector3 (0.0f, pos.y, 0.0f);
		currentTarget = pos;

//		if (!(Input.GetKey (KeyCode.LeftShift) || Input.GetKey (KeyCode.RightShift))) {
//			clear ();
//		}
//
//		GameObject circle = Instantiate (targetCircle, pos, Quaternion.Euler (90f, 0f, 0f));
//		circle.GetComponent<VisualTarget> ().setParent (gameObject);


	}

	/**
	 * Moves the selectedUnit to the cursor position
	 * 
	 * @param targetPos the position 
	 */
	void move () {
		if (currentTarget != Vector3.zero) {
			Vector3 displacement = currentTarget - transform.position;
			displacement.Normalize ();
			rb.MovePosition (transform.position + displacement * Time.deltaTime * speed);
//			currentCircle.transform.position = currentTarget;
			checkDisplacement ();
		} 
	}

	void checkDisplacement () {
		if ((currentTarget - this.transform.position).magnitude < 0.05) {
			currentTarget = Vector3.zero;
		}
	}

//	void clear () {
//		if (currentCircle) {
//			Destroy (currentCircle);
//		}
//		foreach (GameObject circle in targetCircles)
//			Destroy (circle);
//		targetCircles.Clear ();
//		targetPos.Clear ();
//		currentCircle = null;
//		currentTarget = Vector3.zero;
//	}
//
}
