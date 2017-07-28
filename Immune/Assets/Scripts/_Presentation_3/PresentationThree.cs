using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationThree : MonoBehaviour {

	void Awake () {
		TextAnimator ta = this.gameObject.GetComponent<TextAnimator> ();
		ta.nextScene = "Stage_4";
		ta.text = new string[] {
			"<size=80>This is a cell infected by a virus.</size>",
			"First, send a Macrophage to <size=100>CAPTURE</size> the infected cell.", 
			"Afterwards, send a Helper T-Cell to <size=100>ACTIVATE</size> Killer T-Cells.",
			"<size=80>Activated <color=blue>KILLER</color> T-Cells</size> can destroy identical viruses" +
			"<size=90>WITHOUT</size> Helper T-Cells."
		};
	}
}
