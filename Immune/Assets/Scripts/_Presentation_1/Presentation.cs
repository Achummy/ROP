using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Presentation : MonoBehaviour {

	void Awake () {
		Var.infected = false;
		TextAnimator ta = this.gameObject.GetComponent<TextAnimator> ();
		ta.nextScene = "Stage_1";
		ta.text = new string[] {
			"The bright disk represents a <size=120><color=white>WOUND</color></size>.", 
			"<size=80>Platelets</size> will coagulate and close the wound." +
			"                         ", 
			"Now, it's your turn."
		};
	}
}
