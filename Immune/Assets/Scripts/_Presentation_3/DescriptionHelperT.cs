using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionHelperT : MonoBehaviour {

	void Awake () {
		TextAnimator ta = GetComponent<TextAnimator> ();
		ta.text = new string[] {
			"<size=70>Name: Helper T-Cell</size>\n" + 
			"Size: ~12 µm\n" +
			"Function: Activates Immune Cells"
		};
	}
}
