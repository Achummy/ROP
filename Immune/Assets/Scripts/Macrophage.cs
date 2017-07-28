using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macrophage : MonoBehaviour {

	public GameObject macrophage;
	public GameObject target;

	private UnitSelection unitSelection;
	// Use this for initialization
	void Start () {
		unitSelection = Camera.main.GetComponent<UnitSelection> ();
	}
		
	public void createCell () {
		GameObject go = unitSelection.selectedObject;
		if (go) {
			if (go.name.Contains ("Bacteria") | go.name.Contains ("Virus")) {
				GameObject cell = Instantiate (macrophage, new Vector3 (Random.Range (-16.0f, 16.0f), 0.0f, Var.zBoundary), Quaternion.identity);
				Units unit = cell.GetComponent<Units> ();
				unit.addTarget (go.transform.position);

				GameObject tg = Instantiate (target, go.transform);
				tg.transform.parent = go.transform;
			} else {
				Camera.main.GetComponent<Warnings> ().wrongCell (go.name);
			}

		} 
	}
		
}
