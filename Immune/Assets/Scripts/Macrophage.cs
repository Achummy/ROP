using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Macrophage : MonoBehaviour {

	public GameObject macrophage;
	public GameObject target;
	public Text tipsText;

	private UnitSelection unitSelection;
	// Use this for initialization
	void Start () {
		unitSelection = Camera.main.GetComponent<UnitSelection> ();
	}

	void FixedUpdate () {
		if (Var.tipsStartTime + 2.0f < Time.time) {
			tipsText.text = "";
		}
	}
		
	public void createCell () {
		GameObject go = unitSelection.selectedObject;
		if (go) {
			if (go.name.Contains ("Bacteria")) {
				if (go.GetComponent<Bacteria> ().macrophage != null) {
					Var.tipsStartTime = Time.time;
					tipsText.text = "A macrophage is already there!";
				} else {
					sendCell (go);
				}
			} else if (go.name.Contains ("Virus")) {
				if (Virus.recognized) {
					Var.tipsStartTime = Time.time;
					tipsText.text = "It is recognized! Send a Killer T Cell!";
				} else if (go.GetComponent<Virus> ().macrophage != null) {
					Var.tipsStartTime = Time.time;
					tipsText.text = "Send a helper T-Cell!";
				} else {
					sendCell (go);
				}
			} else {
				Var.tipsStartTime = Time.time;
				tipsText.text = "This does not need a macrophage!";
			}
		}
	}

	private void sendCell (GameObject go) {
		GameObject cell = Instantiate (macrophage, new Vector3 (Random.Range (-16.0f, 16.0f), 0.0f, Var.zBoundary), Quaternion.identity);
		Units unit = cell.GetComponent<Units> ();
		unit.addTarget (go.transform.position);

		GameObject tg = Instantiate (target, go.transform);
		tg.transform.parent = go.transform;
	}
		
}
