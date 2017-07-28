using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroPlatelet : MonoBehaviour {

	void Awake () {
		TextAnimator ta = GetComponent<TextAnimator> ();
		ta.nextScene = "Presentation_1";
		ta.text = new string[] {
			"                                \n" +
			"This is a <size=120>platelet</size>.",
			"\nIts main function is to stop your injuries from bleeding.",
			"\nLet me demonstrate it."
		};
	}
}
