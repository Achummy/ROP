using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationTwo : MonoBehaviour {

	void Awake () {
		TextAnimator ta = this.gameObject.GetComponent<TextAnimator> ();
		ta.nextScene = "Stage_2";
		ta.text = new string[] {
			"These yellow rods are <size=120><color=yellow>bacteria</color></size>.",
			"They come through wounds and this is how you get an infection.",
			"<color=yellow>Bacteria</color> <size=110>multiply</size> over time.", 
			"Macrophages <size=80>eat</size> bacteria by <size=100><color=#005FFFFF>Phagocytosis</color></size>.",
			"<size=70>Macrophages die after killing enough <color=yellow>bacteria</color>.</size>",
			"<size=70>Time to try it out yourself.</size>"
		};
	}
}
