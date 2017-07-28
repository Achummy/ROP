using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		TextAnimator ta = GetComponent<TextAnimator> ();
		ta.text = new string[] {
			"<size=200>C.I.S.</size>\n<size=80>Central Immune System</size>"
		};
	}
}
