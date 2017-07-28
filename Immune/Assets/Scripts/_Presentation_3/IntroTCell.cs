using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTCell : MonoBehaviour {

	void Awake () {
		TextAnimator ta = GetComponent<TextAnimator> ();
		ta.nextScene = "Presentation_3";
		ta.text = new string[] {
			"                                " +
			"\nThese are <size=120>T-Cells</size>.",
			"\n<size=110>Helper T-Cell</size> <color=blue>activates</color> other immune cells.",
			"\n<size=110>Killer T-Cell</size> <color=red>destroys</color> infected cells.",
			"\n<size=120>BOTH</size> T-cells need activators.",
			"\n<color=blue>Macrophages</color> activate <size=100>HELPER</size> T-Cells",
			"\n<color=yellow>Helper T-Cells</color> activate <size=100>Killer</size> T-Cells",
			"\nLets try it out."
		};
	}
}
