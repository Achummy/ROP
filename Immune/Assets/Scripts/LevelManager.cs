using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	// Use this for initialization
	public void nextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
		
	public void loadLevel (string name) {
		SceneManager.LoadScene (name);
	}

	public void quitApplication () {
		Application.Quit ();
	}
}
