using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class StageFour : MonoBehaviour {

	public Text text;
	public Image image;
	public GameObject[] spotlight;
	public Text scoreText;

	private enum States {clickselect, sendunits, clear, done};
	private States mystate;

	// Use this for initialization
	void Awake () {
		Var.zBoundary = -15.0f;
		Var.infected = false;
		mystate = States.clickselect;
		Time.timeScale = 0;
		scoreText.text = "Score: "+ Var.score;
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
		if (Input.GetMouseButtonDown (0))
			mystate = States.clear;
	}

	void clear () {
		Time.timeScale = 1;
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=30>Finally, send a <color=blue>killer</color> T-Cell to destroy\n<size=50>all virus</size> of the same type.</size>";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.done;
	}

	void done () {
		image.enabled = false;
		text.enabled = false;
		if (GameObject.FindGameObjectsWithTag("Static").Length == 0) {
			Var.score += (int)Mathf.Floor(120.0f - Time.timeSinceLevelLoad);
			Var.infected = false;
			SceneManager.LoadScene ("Stage_5");
		}
	}


}
