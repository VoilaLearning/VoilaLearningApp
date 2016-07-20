using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickForTextBox : MonoBehaviour, IPointerClickHandler {

	[SerializeField] PictureWordGame pictureWordGame;
	[SerializeField] InputField textInput;

	public void OnPointerClick(PointerEventData eventData){
		Debug.Log ("Click click!");
		if (pictureWordGame.GetGameState () == PictureWordGame.GameState.LABEL_PIC && pictureWordGame.CanLayInput()) {
			// Find all other text box
			InputField[] otherFields = GameObject.FindObjectsOfType<InputField> ();
			// close them 
			for (int i = 0; i < otherFields.Length; i++) {
				if (otherFields [i].GetComponent<InputFieldController> ().IsPinned() == false) {
					otherFields [i].GetComponent<InputFieldController> ().FinishInput ();	
				}
			}

			pictureWordGame.ShowButton ();
			InputField newInput = Instantiate (textInput, Vector3.zero, Quaternion.identity) as InputField;
			newInput.transform.SetParent (this.transform.parent);
			newInput.GetComponent<RectTransform> ().position = Input.mousePosition;
			newInput.transform.localScale = Vector3.one;
		}
	}
}
