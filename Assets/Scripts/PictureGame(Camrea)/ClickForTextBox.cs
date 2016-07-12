using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickForTextBox : MonoBehaviour, IPointerClickHandler {

	[SerializeField] InputField textInput;

	RectTransform CanvasRect;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerClick(PointerEventData eventData){

		Debug.Log ("Clicked here(World Pos): " + Input.mousePosition);
		Debug.Log("Clicked here(Canvas Pos): " + Camera.main.WorldToViewportPoint(Input.mousePosition));
		InputField newInput = Instantiate (textInput, Vector3.zero, Quaternion.identity) as InputField;


		newInput.transform.SetParent (this.transform.parent);
		//newInput.transform.position = Input.mousePosition;
		newInput.GetComponent<RectTransform> ().position = Input.mousePosition;
		newInput.transform.localScale = Vector3.one;
		// newInput.GetComponent<RectTransform> ().localPosition = Camera.main.WorldToViewportPoint (Input.mousePosition);
		// newInput.GetComponent<RectTransform> ().anchoredPosition = mousePos;
	}

	void CreateInputField(){


	}
}
