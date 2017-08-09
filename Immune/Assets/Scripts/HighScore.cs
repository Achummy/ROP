using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

	public Text highscore;
	// Use this for initialization
	void Start () {
		highscore.text = "High Score: " + Var.highscore;
	}

}
