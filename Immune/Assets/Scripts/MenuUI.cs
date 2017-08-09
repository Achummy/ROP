using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour {

	public GameObject pausePanel;
	public Text infectionLevel;
	public Text gameOverText;
	private bool gameOver = false;

	// Use this for initialization
	void Start () {
		gameOverText.enabled = false;
		pausePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (!pausePanel.activeInHierarchy) 
			{
				PauseGame();
			} else
			{
				ContinueGame();   
			}
		}
		if (gameOver) {
			PauseGame ();
			gameOverText.enabled = true;
			if (Input.GetKeyDown (KeyCode.R)) {
				RestartLevel ();
			}
		}
	}
	void FixedUpdate () {
		if (infectionLevel.enabled) {
			GameObject[] bacteria = GameObject.FindGameObjectsWithTag ("Enemy");
			if (bacteria.Length < 100) {
				infectionLevel.text = "Low Infection";
			} else if (bacteria.Length < 200) {
				infectionLevel.text = "<color=yellow>Infected</color>";
			} else {
				infectionLevel.text = "<color=red>High Infection</color>";
				StartCoroutine (impendingDeath ());
			}
		}

		if (Var.score > Var.highscore) {
			Var.highscore = Var.score;
		}
	}

	public void PauseGame () {
		Time.timeScale = 0;
		Var.lastLevel = SceneManager.GetActiveScene ().name;
		pausePanel.SetActive (true);
	}

	public void ContinueGame () {
		Time.timeScale = 1;
		pausePanel.SetActive (false);
	}

	public void RestartLevel () {
		ContinueGame ();
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	public void MainMenu () {
		ContinueGame ();
		Var.lastLevel = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene ("Menu");
	}

	public void Glossary () {
		Time.timeScale = 1;
		SceneManager.LoadScene ("Glossary");
	}

	IEnumerator impendingDeath() {
		while (true) {
			yield return new WaitForSeconds (10.0f);
			if (GameObject.FindGameObjectsWithTag ("Enemy").Length >= 200) {
				gameOver = true;
			} else {
				StopAllCoroutines ();
			}
		}
	}

}
