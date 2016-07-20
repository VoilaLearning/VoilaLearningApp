using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PictureWordGame : MonoBehaviour {

	public enum GameState {
		INTRO = 0,
		TAKE_PIC,
		LABEL_PIC,
		SHOW_RESULTS,
	}
	public GameState currentGameState;
	public GameState lastGameState;

	[Header("Game Data:")]
	[SerializeField] string[] wordsToFind;
	[SerializeField] InputField[] wordsWritten;

	[Header("In Game UI:")]
	[SerializeField] Button checkWordsButton;
	[SerializeField] GameObject introStateUI;
	[SerializeField] GameObject takePicStateUI;
	[SerializeField] GameObject labelPictureStateUI;
	[SerializeField] GameObject showResultsStateUI;

	[SerializeField] GameObject notifyTakePic;
	[SerializeField] Text[] wordsToFindUI;
	[SerializeField] Text[] wordsToFindReminderUI;

	string[] wordsFound;
	int wordCount;
	bool pictureLoaded;

	void Start(){
		Screen.orientation = ScreenOrientation.LandscapeLeft;
		currentGameState = GameState.INTRO;
		introStateUI.SetActive (true);
		pictureLoaded = false;

		for (int i = 0; i < wordsToFindUI.Length; i++) {
			wordsToFindUI [i].text = (i + 1).ToString() + ". " + wordsToFind [i];
		}
	}

	public void CheckWords(){
		wordsWritten = GameObject.FindObjectsOfType<InputField> ();
		wordCount = 0;

		for (int i = 0; i < wordsWritten.Length; i++) {
			CheckWord(i);
		}

		Debug.Log ("Word Count: " + wordCount);
		// showResultsStateUI.SetActive (true);
		SetGameState(3);

		if (wordCount == wordsToFind.Length) {
			showResultsStateUI.transform.FindChild ("Win").gameObject.SetActive (true);
			showResultsStateUI.transform.FindChild ("Try Again").gameObject.SetActive (false);
		} else {
			showResultsStateUI.transform.FindChild ("Win").gameObject.SetActive (false);
			showResultsStateUI.transform.FindChild ("Try Again").gameObject.SetActive (true);
		}
	}

	void CheckWord(int index){
		foreach (InputField input in wordsWritten) {
			if (input.text.ToLower() == wordsToFind [index].ToLower()) {
				Debug.Log ("Found Word!");
				wordCount++;
				break;
			}
		}
	}

	void ToggleState(GameState state, bool toggle){
		switch (state) {
		case GameState.INTRO:
			introStateUI.SetActive (toggle);
			break;
		case GameState.TAKE_PIC:
			// Find all the input fields and dleete the - if there are any
			InputField[] placedWords = GameObject.FindObjectsOfType<InputField> ();
			if (placedWords != null) {
				for (int i = 0; i < placedWords.Length; i++) {
					placedWords [i].GetComponent<InputFieldController> ().DestroyField ();
				}
			}
			takePicStateUI.SetActive (toggle);
			break;
		case GameState.LABEL_PIC:
			labelPictureStateUI.SetActive (toggle);
			break;
		case GameState.SHOW_RESULTS:
			showResultsStateUI.SetActive (toggle);
			break;
		default:
			break;
		}
	}

	public void SetGameState(int state){
		if ((currentGameState == GameState.TAKE_PIC && pictureLoaded) || currentGameState != GameState.TAKE_PIC) {
			lastGameState = currentGameState;
			currentGameState = (GameState)state;
			ToggleState (currentGameState, true);
			ToggleState (lastGameState, false);
		} else {
			notifyTakePic.SetActive (true);
			Debug.Log("Please Take and Load a Picture");
		}

		Debug.Log ("Current State: " + currentGameState + " Last State: " + lastGameState);
	}

	public void ShowButton(){
		if (!checkWordsButton.gameObject.activeSelf) {
			checkWordsButton.gameObject.SetActive (true);
		}
	}

	public void HideButton(){
		InputField[] tempInput = GameObject.FindObjectsOfType<InputField> ();
		// Debug.Log (tempInput.Length);
		if (tempInput.Length == 1) {
			GameObject.FindGameObjectWithTag ("WordsButton").SetActive (false);
		}
	}

	public void SetPictureLoaded(bool state){
		pictureLoaded = state;
	}

	public GameState GetGameState(){
		return currentGameState;
	}

	public void ShowReminder(){
		for (int i = 0; i < wordsToFindReminderUI.Length; i++) {
			wordsToFindReminderUI [i].text = wordsToFind [i];
		}
	}
}
