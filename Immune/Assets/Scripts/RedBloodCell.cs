using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RedBloodCell : MonoBehaviour {

	public GameObject rbc;
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
			if (go.name.Contains ("Wound")) {
				StartCoroutine (redCells (go.transform.position, go));
			} else {
				Var.tipsStartTime = Time.time;
				tipsText.text = "This is not a Wound!";
			}
		}
	}

	IEnumerator redCells(Vector3 target, GameObject go) {
		int wound = go.GetComponent<Wound> ().size;
		for (int i = 0; i < wound; i++) {
			GameObject cell = Instantiate (rbc, new Vector3 (Random.Range(-16.0f, 16.0f),0.0f, Var.zBoundary), Quaternion.identity);
			Units unit = cell.GetComponent<Units> ();
			unit.addTarget(target);
			yield return new WaitForSeconds (0.3f);
		}
	}
		
}
