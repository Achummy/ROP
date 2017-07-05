using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class StageOne : MonoBehaviour {

	public Text text;
	public Image image;
	public GameObject[] spotlight;
	private UnitSelection unitSelection;

	private enum States {clickselect, sendunits, clear, done};
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
		text.text = "<color=#00B5FF>LEFT-CLICK</color> any <color=w>wound</color> to select it.";
		if (unitSelection.selectedObject) 
			mystate = States.sendunits;
	}

	void sendUnits () {
		image.enabled = true;
		text.enabled = true;
		text.text = "<color=#00B5FF>LEFT-CLICK</color> the <color=red>Red Blood Cell</color> at the bottom of the screen to send them.";
		if (GameObject.FindGameObjectsWithTag("Unit").Length != 0)
			mystate = States.clear;
	}



	void clear () {
		image.enabled = true;
		text.enabled = true;
		text.text = "Great! Close the remaining wounds!";
		if (Input.GetMouseButtonDown(0)) 
			mystate = States.done;
	}

	void done () {
		image.enabled = false;
		text.enabled = false;
		int inactive = 0;
		foreach (GameObject go in spotlight) if (!go.activeInHierarchy) inactive++;
		if (inactive == 3) {
			SceneManager.LoadScene ("Presentation_2");
		}
	}


}
