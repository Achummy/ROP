using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentationThree : MonoBehaviour {

	void Awake () {
		TextAnimator ta = this.gameObject.GetComponent<TextAnimator> ();
		ta.nextScene = "Stage_4";
		ta.text = new string[] {
			"<size=100>Virus...Virus...Virus...</size> \nWhy do you even exist.", 
			"They don't multiply as much as bacterias but they <size=120>KILL</size> cells.", 
			"Time to call for new <size=80>leukocytes</size>, <size=120>T-Cells!</size>.", 
			"They destroy viruses and cancer cells. However, they need the help of macrophages.",
			"Macrophages eats the virus and activates <size=80><color=white>HELPER</color> T-Cells.</size>",
			"Afterwards, you can send a <size=80><color=blue>KILLER</color> T-Cells</size> to destroy them."
		};
	}
}
