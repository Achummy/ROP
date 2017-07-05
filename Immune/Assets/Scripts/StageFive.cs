﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageFive : MonoBehaviour {


	public Text text;
	public Image image;
	public GameObject[] spotlight;

	private enum States {clickselect, sendunits, clear, done};
	private States mystate;

	// Use this for initialization
	void Awake () {
		Var.infected = true;
		mystate = States.clickselect;
		Time.timeScale = 0;
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
		text.text = "<size=40>First, send a macrophage to 'capture' a virus.</size>";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.sendunits;
	}

	void sendUnits () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=30>Then, send a <color=white>helper</color> T-Cell to 'analyze' the virus.</size>";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.clear;
	}

	void clear () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=30>Finally send a <color=blue>killer</color> T-Cell to kill <size=50>all virus</size> of the same type.</size>";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.done;
	}

	void done () {
		Time.timeScale = 1;
		image.enabled = false;
		text.enabled = false;
		if (GameObject.FindGameObjectsWithTag("Static").Length == 0) {
			Var.infected = false;
			SceneManager.LoadScene ("Stage_5");
		}
	}
}