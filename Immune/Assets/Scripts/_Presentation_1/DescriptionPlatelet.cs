using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionPlatelet : MonoBehaviour {

	void Awake () {
		TextAnimator ta = GetComponent<TextAnimator> ();
		ta.text = new string[] {
			"<size=70>Name: Platelet</size>\n" + 
			"Size: 2-3 µm\n" +
			"Function: Stops bleedings"
		};
	}
}
