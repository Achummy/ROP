using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public float loadNextLevelAfter;
	// Use this for initialization
	void Start () {
		Invoke ("nextLevel", loadNextLevelAfter);
	}

	public void nextLevel () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void loadLastLevel () {
		if (Var.lastLevel != null) {
			SceneManager.LoadScene (Var.lastLevel);
		} else {
			nextLevel ();
		}
	}
		
	public void loadLevel (string name) {
		SceneManager.LoadScene (name);
	}

	public void quitApplication () {
		Application.Quit ();
	}
}
