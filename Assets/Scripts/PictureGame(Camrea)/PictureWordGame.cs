using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PictureWordGame : MonoBehaviour {

	[SerializeField] string[] wordsToFind;
	[SerializeField] InputField[] wordsWritten;
	[SerializeField] Button checkWordsButton;
	[SerializeField] Text winImage;

	string[] wordsFound;
	int wordCount;

	public void CheckWords(){
		wordsWritten = GameObject.FindObjectsOfType<InputField> ();

		CheckWord(0);
		CheckWord(1);
		CheckWord(2);

		Debug.Log ("Word Count: " + wordCount);

		if (wordCount == wordsToFind.Length) {
			winImage.gameObject.SetActive (true);
		}
	}

	void CheckWord(int index){
		foreach (InputField input in wordsWritten) {
			if (input.text == wordsToFind [index]) {
				Debug.Log ("Found Word!");
				wordCount++;
				break;
			}
		}
	}

	public void ShowButton(){
		// Debug.Log ("Showing Button");
		if (!checkWordsButton.gameObject.activeSelf) {
			checkWordsButton.gameObject.SetActive (true);
		}
	}

	public void HideButton(){
		// Debug.Log ("Hiding Button");

		InputField[] tempInput = GameObject.FindObjectsOfType<InputField> ();
		// Debug.Log (tempInput.Length);
		if (tempInput.Length == 1) {
			GameObject.FindGameObjectWithTag ("WordsButton").SetActive (false);
		}
	}
}
