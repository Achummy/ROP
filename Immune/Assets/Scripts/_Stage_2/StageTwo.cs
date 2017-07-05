using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageTwo : MonoBehaviour {

	public Text text;
	public Image image;
	private UnitSelection unitSelection;

	private enum States {clickselect, done};
	private States mystate;

	// Use this for initialization
	void Awake () {

		unitSelection = Camera.main.gameObject.GetComponent<UnitSelection> ();
		mystate = States.clickselect;

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
		text.text = "You know what to do!\n<color=#00B5FF>Look</color> at the new button!";
		if (unitSelection.selectedObject) 
			mystate = States.done;
	}


	void done () {
		image.enabled = false;
		text.enabled = false;
		if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
			SceneManager.LoadScene ("Stage_3");
		}
	}


}