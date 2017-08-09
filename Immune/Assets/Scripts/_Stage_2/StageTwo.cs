using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageTwo : MonoBehaviour {

	public Text text;
	public Image image;
	public Text scoreText;
	private UnitSelection unitSelection;

	private enum States {clickselect, done};
	private States mystate;

	// Use this for initialization
	void Awake () {
		Var.zBoundary = -10.0f;
		unitSelection = Camera.main.gameObject.GetComponent<UnitSelection> ();
		mystate = States.clickselect;
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
		text.text = "<color=#00B5FF>Look</color> at the new button!\n You can now send Macrophages.";
		if (unitSelection.selectedObject) 
			mystate = States.done;
	}


	void done () {
		image.enabled = false;
		text.enabled = false;
		if (GameObject.FindGameObjectsWithTag("Static").Length == 0) {
			Var.score += (int)Mathf.Floor(120.0f - Time.timeSinceLevelLoad);
			SceneManager.LoadScene ("Stage_2.5");
		}
	}


}