using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualTarget : MonoBehaviour {

	Transform tf;
	bool forward;
	GameObject parent;

	void Start () {
		tf = this.transform;
		forward = true;
	}
	// Update is called once per frame
	void Update () {
		scale ();
		if (!parent) {
			Destroy (gameObject);
		}
	}

	void scale () {
		
		if (forward) {
			tf.localScale -= Vector3.one * Time.deltaTime * 2;
		} else {
			tf.localScale += Vector3.one * Time.deltaTime * 2;
		}

		if (tf.localScale.x >= 0.8f) {
			forward = true;
		} else if (tf.localScale.x <= -0.8f){
			forward = false;
		}
	}

	public void setParent(GameObject parent) {
		this.parent = parent;
	}
}
