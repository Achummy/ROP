using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelperTcell : MonoBehaviour {

	public GameObject htc;
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
			if (go.name.Contains ("Virus")) {
				if (Virus.recognized) {
					Var.tipsStartTime = Time.time;
					tipsText.text = "It is recognized! Send a Killer T-Cell.";
				} else if (go.GetComponent<Virus>().macrophage != null) {
					GameObject cell = Instantiate (htc, new Vector3 (Random.Range (-16.0f, 16.0f), 0.0f, Var.zBoundary), Quaternion.identity);
					Units unit = cell.GetComponent<Units> ();
					unit.addTarget (go.transform.position);

					GameObject tg = Instantiate (target, go.transform);
					tg.transform.parent = go.transform;
				} else {
					Var.tipsStartTime = Time.time;
					tipsText.text = "Send a Macrophage!";
				}
			} else {
				Var.tipsStartTime = Time.time;
				tipsText.text = "This is not a Virus!";
			}
		}
	}
}
