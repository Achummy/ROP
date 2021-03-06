﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class StageOne : MonoBehaviour {

	public Text text;
	public Image image;
	public GameObject[] wounds;
	private UnitSelection unitSelection;

	private enum States {clickselect, sendunits, clear, firststage, movecamera};
	private States mystate;

	// Use this for initialization
	void Awake () {
		Var.infected = false;
		Var.zBoundary = -10.0f;
		unitSelection = Camera.main.gameObject.GetComponent<UnitSelection> ();
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

	void clickSelect () {
		Time.timeScale = 0;
		image.enabled = true;
		text.enabled = true;
		text.text = "<color=#00B5FF>LEFT-CLICK</color> any <color=w>wound</color> to select it.";
		if (unitSelection.selectedObject) 
			mystate = States.sendunits;
	}

	void sendUnits () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<color=#00B5FF>LEFT-CLICK</color> the <color=red>Platelet</color> at the bottom of the screen to send them.";
		if (GameObject.FindGameObjectsWithTag ("Unit").Length != 0) {
			mystate = States.clear;
			Time.timeScale = 1;
		}
	}

	void clear () {
		image.enabled = true;
		text.enabled = true;
		text.text = "Great! Close the remaining wounds!";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.firststage;
	}

	void firststage () {
		image.enabled = false;
		text.enabled = false;
		int inactive = 0;
		foreach (GameObject go in wounds) if (!go.activeInHierarchy) inactive++;
		if (inactive == 3) {
			Var.score += (int)Mathf.Floor(120.0f - Time.timeSinceLevelLoad);
			SceneManager.LoadScene ("Stage_1.5");
		}
	}

}
