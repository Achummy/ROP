using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroMacrophage : MonoBehaviour {

	void Awake () {
		TextAnimator ta = GetComponent<TextAnimator> ();
		ta.nextScene = "Presentation_2";
		ta.text = new string[] {
			"                                " +
			"\n<size=120>Macrophage</size>",
			"\nA cell that eats foreign entities in your body such as \n<size=110>bacteria</size> and <size=110>viruses</size>.",
			"\nThis process is called <size=120><color=#005FFFFF>PHAGOCYTOSIS</color></size>.",
			"\nLets see how it works."
		};
	}
}
