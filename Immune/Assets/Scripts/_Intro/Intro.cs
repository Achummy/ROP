using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Var.subjectNumber++;
		Var.score = 0;
		TextAnimator ta = GetComponent<TextAnimator> ();
		ta.nextScene = "Platelet";
		ta.text = new string[] {
			"Hello ... \n   Subject # " + Var.subjectNumber + "\n   You have been assigned a new mission.",
			"Objective:  <size=120><color=#005FFFFF>protect</color></size> your body. \nDescription: <color=yellow>defective</color> immune system...",
			"You will have to control <color=#00FF4CFF>white blood cells</color> to defend yourself against <color=red>bacteria</color>.",
			"White blood cells are also known as <size=120>LEUKOCYTES</size>.",
			"Time to start your training."
		};
	}

}
