using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {

	public Texture2D cell;
	public GameObject rbc;

	bool selected;


	// Use this for initialization
	void Start () {
		selected = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void isSelected(bool s) {
		selected = s;
	}

	void OnGUI () {
		if (selected) {
			GUI.Box (new Rect(0.0f, Screen.height - Screen.height*0.2f, Screen.width, Screen.height*0.2f), "Blood Vessel");
			if (GUI.Button (new Rect (20.0f, Screen.height - Screen.height * 0.17f, 150.0f, 90.0f), cell))
				Instantiate(rbc, transform.position + new Vector3(Random.Range(-2f, 2f), 0.0f, Random.Range(0f, 4f)), Quaternion.identity);
		}
	}
}
