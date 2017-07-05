using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RedBloodCell : MonoBehaviour {

	public GameObject rbc;

	private UnitSelection unitSelection;
	// Use this for initialization
	void Start () {
		unitSelection = Camera.main.GetComponent<UnitSelection> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void createCell () {
		GameObject go = unitSelection.selectedObject;
		if (go) {
			if (go.name.Contains ("Wound")) {
				StartCoroutine (redCells (go.transform.position, (int)go.GetComponent<Light> ().intensity));
			} else if (go.name.Contains ("Bacteria")) {
				StartCoroutine (redCells (go.transform.position, go.GetComponent<Bacteria> ().bacterias.Count));
			}
		}
	}

	IEnumerator redCells(Vector3 target, int intensity) {
		for (int i = 0; i < intensity; i++) {
			GameObject cell = Instantiate (rbc, new Vector3 (Random.Range(-16.0f, 16.0f),0.0f, -28.0f), Quaternion.identity);
			Units unit = cell.GetComponent<Units> ();
			unit.addTarget(target);
			yield return new WaitForSeconds (0.3f);
		}
	}
		
}
