using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * <summary>Class <c>TextAnimator</c> animates a text (in a typewriter fashion). </summary>
 */
public class TextAnimator : MonoBehaviour {

	public Text textBox;
	public Text continueText;
	public float textSpeed = 0.02f;
	public string nextScene { get; set;}
	public string[] text { get; set;}


	private int currentTextDisplayed = 0;
	private bool textDisplayed = false;

	void Start () {
		StartCoroutine(AnimateText());
	}

	void Update () {
		if (Input.anyKey) {
			if (textDisplayed && currentTextDisplayed < text.Length - 1) {
				SkipToNextText ();
			} else if (currentTextDisplayed == text.Length - 1 && textDisplayed && nextScene != null) {
				SceneManager.LoadScene (nextScene);
			}
		}

		displayContinue ();
	}

	/**
	 * <summary> Animates a string like a typewriter.
	 * String may contain RichText tags. </summary>
	 */
	private IEnumerator AnimateText(){
		string richText = "";
		for (int i = 1; i < (text[currentTextDisplayed].Length+1); i++)
		{
			//Skips RichText tags
			if (text [currentTextDisplayed] [i-1] == '<') {
				richText += text[currentTextDisplayed][i-1];
				while (text [currentTextDisplayed] [i-1] != '>') {
					i++;
					richText += text[currentTextDisplayed][i-1];
				}
			} else {
				textBox.text = text[currentTextDisplayed].Substring(0, i) + adjustRichText(richText);
				yield return new WaitForSeconds(textSpeed);
			}
		}
		yield return new WaitForSeconds (0.5f);
		textDisplayed = true;
	}

	/**
	 * <summary> Stops the current animated string and animates the following string if available.</summary>
	 */
	private void SkipToNextText(){
		StopAllCoroutines();
		textDisplayed = false;
		currentTextDisplayed++;
		StartCoroutine(AnimateText());
	}

	/**
	 * <summary>Returns a string that closes any unclosed RichText tags in <paramref name = "text"/></summary>
	 * <param name ="text"> a string containing RichText tags</param>
	 */
	private string adjustRichText (string text) {
		int size, color, b, i;
		size = color = b = i = 0;

		String[] tags = text.Split ('>');
		foreach (string tag in tags) {
			if (tag.Contains ("size")) 			size++; 
			else if (tag.Contains ("color")) 	color++;
			else if (tag.Contains ("b")) 		b++;
			else if (tag.Contains ("i")) 		i++;
		}

		string returnText = "";
		if (color % 2 != 0) returnText += "</color>";
		if (size % 2 != 0) 	returnText += "</size>";
		if (b % 2 != 0) 	returnText += "</b>";
		if (i % 2 != 0) 	returnText += "</i>";

		return returnText;
	}

	/**
	 * <summary> Displays <c>continueText</c> when <c>textDisplayed</c> is true. </summary>
	 */
	private void displayContinue () {
		if (continueText != null) {
			if (textDisplayed) {
				continueText.enabled = true;
			} else {
				continueText.enabled = false;
			}
		}
	}
		
//	void OnGUI () {
//		// Creates a Grey Rectangle with 80% opacity, full screen width and 35% of the screen height
//		// anchored at the bottom of the screen.
//		GUI.color = new Color (0.5f, 0.5f, 0.5f, 0.8f);
//		GUI.Box (new Rect(0.0f, Screen.height - Screen.height*0.35f, Screen.width, Screen.height*0.35f), "");
//	}

}
