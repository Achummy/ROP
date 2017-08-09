using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageFive : MonoBehaviour {


	public Text text;
	public Image image;
	public GameObject[] spotlight;
	public Text scoreText;

	private enum States {clickselect, sendunits, clear, done};
	private States mystate;

	// Use this for initialization
	void Awake () {
		Var.zBoundary = -20.0f;
		Var.infected = true;
		mystate = States.clickselect;
		Time.timeScale = 0;
		scoreText.text = "Score: "+ Var.score;
	}

	// Update is called once per frame
	void Update () {
		if (mystate == States.clickselect)
			clickSelect ();
		else if (mystate == States.done)
			done ();
	}

	void clickSelect () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=40>Time to combine everything\nyou've learned so far.</size>";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.done;
	}

	void done () {
		Time.timeScale = 1;
		image.enabled = false;
		text.enabled = false;
		if (GameObject.FindGameObjectsWithTag("Static").Length == 0) {
			Var.score += (int)Mathf.Floor(120.0f - Time.timeSinceLevelLoad);
			Var.infected = false;
			SceneManager.LoadScene ("End");
		}
	}
}
