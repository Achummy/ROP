using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Warnings : MonoBehaviour {

	public Text text;
	public Image image;
	private MenuUI ui;
	private string sceneName;
	private float pausedTime;
	private bool pausedGame;
	private bool wrong;
	// Use this for initialization
	void Start () {
		sceneName = SceneManager.GetActiveScene ().name;
	}
	
	// Update is called once per frame
	void Update () {
//		if (Time.time > 30.0f & !pausedGame) {
//			text.enabled = true;
//			image.enabled = true;
//			if (sceneName == "Stage_2") {
//				text.text = "You must send macropahges to the bacteria before they multiply!";
//			} else if (sceneName == "Stage_3") {
//				text.text = "Close the wounds first! Deal with bacteria after!";
//			} else if (sceneName == "Stage_4") {
//				text.text = "First send a macrophage, then send a helper T-Cell, afterwards, send a Killer T-Cell.";
//			} else if (sceneName == "Stage_5") {
//				text.text = "Try to close wounds first! Use the menu if you forget what to do!";
//			}
//			Time.timeScale = 0;
//			pausedTime = Time.time;
//			pausedGame = true;
//		} 
//
//		if (pausedGame & Input.anyKeyDown) {
//				Time.timeScale = 1;
//				text.enabled = false;
//				image.enabled = false;
//		}
		if (wrong) {
			if (Input.anyKeyDown) {
				text.enabled = false;
				image.enabled = false;
				wrong = false;
			}
		}
	}

	public void wrongCell (string name) {
		text.enabled = true;
		image.enabled = true;
		wrong = true;
		if (name.Contains("Bacteria")) {
			text.text = "You need to send macrophages to bacteria!";
		} if (name.Contains("Wound")) {
			text.text = "You need to send platelet to wounds!";
		}
	}
//	void pauseGame () {
//		
//	}
}
