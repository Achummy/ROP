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
			"Here, we have a <size=120>wound</size> on my skin!", 
			"There is light coming through and we need to clog that up.", 
			"Here comes the <size=100>Platelets</size>! They will coagulate and close the wound.", 
			"It's <size=120>CLOSING</size>. Now, it's your turn!"
		};
	}
}
