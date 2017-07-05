using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class StageThree : MonoBehaviour {

	public Text text;
	public Image image;
	public GameObject[] spotlight;

	private enum States {clickselect, sendunits, clear, done};
	private States mystate;

	// Use this for initialization
	void Awake () {
		Var.infected = true;
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
		else if (mystate == States.done)
			done ();
	}

	void clickSelect () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=70>Other wounds got INFECTED!!!</size>";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.sendunits;
	}

	void sendUnits () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=60>Close my wounds first! Bacterias are coming.</size>";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.clear;
	}

	void clear () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=40>Keep track of my infection level! Don't let me die!</size>";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.done;
	}

	void done () {
		image.enabled = false;
		text.enabled = false;
		if (GameObject.FindGameObjectsWithTag("Static").Length == 0) {
			Var.infected = false;
			SceneManager.LoadScene ("Presentation_3");
		}
	}


}
