using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macrophage : MonoBehaviour {

	public GameObject macrophage;

	private UnitSelection unitSelection;
	// Use this for initialization
	void Start () {
		unitSelection = Camera.main.GetComponent<UnitSelection> ();
	}
		
	public void createCell () {
		GameObject go = unitSelection.selectedObject;
		if (go) {
			GameObject cell = Instantiate (macrophage, new Vector3 (Random.Range(-16.0f, 16.0f),0.0f, -28.0f), Quaternion.identity);
			Units unit = cell.GetComponent<Units> ();
			unit.addTarget(go.transform.position);
		} 
	}
		
}
