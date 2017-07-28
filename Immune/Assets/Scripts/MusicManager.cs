using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Awake () {
		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void Update () {
		if (audioSource.volume < 0.1) {
			fadeIn ();
		}
	}

	void OnLevelWasLoaded (int level) {
		if (levelMusicChangeArray[level]) {
			audioSource.clip = levelMusicChangeArray [level];
			audioSource.loop = true;
			audioSource.Play ();
		}
	}

	void fadeIn () {
		audioSource.volume += 0.01f * Time.deltaTime;
	}
}
