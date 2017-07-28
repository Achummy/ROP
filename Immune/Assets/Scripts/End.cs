using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		TextAnimator ta = GetComponent<TextAnimator> ();
		ta.nextScene = "Platelet";
		ta.text = new string[] {
			"Bravo! Subject # " + Var.subjectNumber + "\n You have completed your training...",
			"This is where your journey begins... \n                     <color=#7A7A7AFF>To be continued...</color>"
		};
	}
}
