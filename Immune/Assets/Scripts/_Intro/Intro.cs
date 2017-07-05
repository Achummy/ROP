using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		TextAnimator ta = this.gameObject.GetComponent<TextAnimator> ();
		ta.nextScene = "Presentation_1";
		ta.text = new string[] {
			"<size=120>GREETINGS</size> little ones!",
			"You will manipulate <size=120><color=red>cells</color></size> to <size=150>protect</size> me.", 
			"Hopefully...", 
			"These cells, <size=120>LEUKOCYTES</size>, move through veins and the <size=100>LYMPH</size>.",
			"They are commonly known as <color=white>white blood cells</color>.",
			"Anyways, lets move on..."
		};
	}

}
