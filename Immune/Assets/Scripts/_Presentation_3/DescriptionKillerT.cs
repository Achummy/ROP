using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionKillerT : MonoBehaviour {

	void Awake () {
		TextAnimator ta = GetComponent<TextAnimator> ();
		ta.text = new string[] {
			"<size=70>Name: Killer T-Cell</size>\n" + 
			"Size: ~12 µm\n" +
			"Function: Destroys unrecognized cells"
		};
	}
}
