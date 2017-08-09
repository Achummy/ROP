using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageTwoAdv : MonoBehaviour {

	public Text text;
	public Image image;
	public Text scoreText;
	public Image antibiotic;

	private enum States {clickselect, sendunits, clear, firststage, antibiotics, killthecells};
	private States mystate;

	// Use this for initialization
	void Awake () {
		antibiotic.enabled = false;
		Var.infected = true;
		Var.zBoundary = -10.0f;
		mystate = States.clickselect;
		scoreText.text = "Score: " + Var.score;
	}

	// Update is called once per frame
	void Update () {
		if (mystate == States.clickselect)
			clickSelect ();
		else if (mystate == States.sendunits)
			sendUnits ();
		else if (mystate == States.clear)
			clear ();
		else if (mystate == States.firststage)
			firststage ();
		else if (mystate == States.antibiotics)
			antibiotics ();
		else if (mystate == States.killthecells)
			killthecells ();
	}
		
	void clickSelect () {
		Time.timeScale = 0;
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=35>Bacteria multiply extremly rapidly.</size>";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.sendunits;
	}

	void sendUnits () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=35>The immune system can be overwhelmed.</size>";
		if (Input.GetMouseButtonDown(0)) {
			mystate = States.clear;
		}
	}

	void clear () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=35>Destroy as many as you can.</size>";
		if (Input.GetMouseButtonDown (0)) {
			mystate = States.firststage;
			Time.timeScale = 1;
		} 
	}

	void firststage () {
		image.enabled = false;
		text.enabled = false;
		if (Time.timeSinceLevelLoad > 18) {
			mystate = States.antibiotics;
		}
	}

	void antibiotics () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=35>When the body is overwhelmed, we use antiobiotics.</size>";
		if (Time.timeSinceLevelLoad > 22) {
			mystate = States.killthecells;
		} 
	}

	void killthecells () {
		text.text = "<size=35>A human made chemical to kill bacteria.\nUse it now.</size>";
		antibiotic.enabled = true;
	}
}
