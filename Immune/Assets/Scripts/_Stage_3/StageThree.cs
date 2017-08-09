using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class StageThree : MonoBehaviour {

	public Text text;
	public Image image;
	public GameObject[] wounds;
	public GameObject[] bacteria;
	public Text scoreText;
	public Text bonus;
	private bool bonusScore = true;

	private enum States {clickselect, sendunits, clear, done};
	private States mystate;

	// Use this for initialization
	void Awake () {
		Var.infected = true;
		Var.zBoundary = -10.0f;
		mystate = States.clickselect;
		Time.timeScale = 0;
		bonus.text = "";
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
		
		if (bonusScore) {
			int inactiveWounds = 0;
			foreach (GameObject go in wounds) if (!go.activeInHierarchy) inactiveWounds++;
			int inactiveBacteria = 0;
			foreach (GameObject bac in bacteria) if (!bac.activeInHierarchy) inactiveBacteria++;
			if (inactiveWounds == 2) {
				bonus.color = Color.grey;
				Var.score += 50;
				bonusScore = false;
			} else if (inactiveBacteria > 0) {
				bonus.text = "Bonus Failed";
				bonus.color = Color.grey;
				bonusScore = false;
			}
		}
	}

	void FixedUpdate () {
		scoreText.text = "Score: "+ Var.score;
	}

	void clickSelect () {
		image.enabled = true;
		text.enabled = true;
		text.text = "Great!\nNow, lets see how you deal with wounds AND bacteria.";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.sendunits;
	}

	void sendUnits () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<size=60><color=blue>Remember</color></size>:\nbacteria <color=red>MULTIPLY</color> and <color=red>COME OUT</color> of wounds.";
		if (Input.GetMouseButtonDown (0)) {
			mystate = States.clear;
		}
	}

	void clear () {
		image.enabled = true;
		text.enabled = true;
		text.text = "You <color=red>lose</color> if too many bacteria are present.";
		if (Input.GetMouseButtonDown (0)) {
			bonus.text = "<i>Clear the wounds first</i>";
			mystate = States.done;
			Time.timeScale = 1;
		}
	}

	void done () {
		image.enabled = false;
		text.enabled = false;
		if (GameObject.FindGameObjectsWithTag("Static").Length == 0) {
			Var.score += (int)Mathf.Floor(120.0f - Time.timeSinceLevelLoad);
			Var.infected = false;
			SceneManager.LoadScene ("TCells");
		}
	}


}
