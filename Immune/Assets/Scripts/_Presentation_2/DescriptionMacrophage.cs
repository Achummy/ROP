using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionMacrophage : MonoBehaviour {
	
	void Awake () {
		TextAnimator ta = GetComponent<TextAnimator> ();
		ta.text = new string[] {
			"<size=70>Name: Macrophage</size>\n" + 
			"Size: 21 µm\n" +
			"Function: Eats unrecognized cells"
		};
	}
}
