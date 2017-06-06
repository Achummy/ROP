using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units : MonoBehaviour {

	Rigidbody rb;
	Vector3 targetPos;
	float speed = 3;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		targetPos = transform.position;
	}
	// Update is called once per frame
	void FixedUpdate () {
		move ();
	}


	public void setTarget (Vector3 pos) {
		targetPos = pos;
	}

	/**
	 * Moves the selectedUnit to the cursor position
	 * 
	 * @param targetPos the position 
	 */
	void move () {

		if (targetPos != transform.position) {
			Vector3 displacement = targetPos - transform.position;
			if (displacement.magnitude > 1) {
				displacement.Normalize ();
			}
			rb.MovePosition(transform.position + displacement * Time.deltaTime * speed);
		} 
	}
}
