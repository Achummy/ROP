using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationTwo : MonoBehaviour {

	void Awake () {
		TextAnimator ta = this.gameObject.GetComponent<TextAnimator> ();
		ta.nextScene = "Stage_2";
		ta.text = new string[] {
			"<size=120>OH NO!<color=yellow>BACTERIAS!</color></size> \nThey came through my wounds!", 
			"<size=100><color=yellow>BACTERIAS</color></size> multiply over time.", 
			"Luckily, we have <size=100>LEUKOCYTES</size> (aka white blood cells).", 
			"The one that <size=80>eats</size> bacterias are called <size=120>MACROPHAGES</size>.",
			"<size=80>Macrophages</size> <size=20>sadly</size> <size=80>dies after killing enough <color=yellow>bacterias</color>.</size>",
			"<size=80>Now, help me fend off the rest of them.</size>"
		};
	}
}
