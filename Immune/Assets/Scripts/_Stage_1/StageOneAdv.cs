using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageOneAdv : MonoBehaviour {

	public Text text;
	public Image image;
	public GameObject[] wounds;
	public Text scoreText;
	private int startScore;

	private enum States {clickselect, sendunits, clear, firststage, movecamera};
	private States mystate;

	// Use this for initialization
	void Awake () {
		startScore = Var.score;
		Var.infected = false;
		Var.zBoundary = -10.0f;
		mystate = States.clickselect;
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
	}

	void FixedUpdate () {
		int inactive = 0;
		foreach (GameObject go in wounds) if (!go.activeInHierarchy) inactive++;
		Var.score = startScore + (inactive * 50);
		scoreText.text = "Score: "+ Var.score;
	}

	void clickSelect () {
		Time.timeScale = 0;
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=35>A HUGE wound appeared near my vein.</size>";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.sendunits;
	}

	void sendUnits () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=35>The immune system <b>NEVER</b> waits.\nIt reacts <b>VERY</b> quickly.</size>";
		if (Input.GetMouseButtonDown(0)) {
			mystate = States.clear;
		}
	}

	void clear () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=35>You have 20 seconds.\nThe more you clear, the better your score.</size>";
		if (Input.GetMouseButtonDown (0)) {
			mystate = States.firststage;
			Time.timeScale = 1;
		} 
	}

	void firststage () {
		image.enabled = false;
		text.enabled = false;
	}
}
