using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour {

	[SerializeField] GameObject destroyButton;
	[SerializeField] GameObject editButton;

	bool closed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DestroyField(){
		Destroy (this.gameObject);
	}

	public void FinishInput(){
		// Make it no longer interractable
		this.GetComponent<InputField>().interactable = false;
		// Shrink Box Down 0.5, 0.5, 0.5
		this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		// Deactivate Destroy Button
		destroyButton.SetActive(false);
		// Activate the re-open Button
		editButton.SetActive(true);
		closed = true;
	}

	public void OpenInputField(){
		InputField[] tempArray = GameObject.FindObjectsOfType<InputField> ();
		for (int i = 0; i < tempArray.Length; i++) {
			if (tempArray [i].GetComponent<InputFieldController> ().IsClosed() == false) {
				tempArray [i].GetComponent<InputFieldController> ().FinishInput ();
			}
		}

		// Make it interractable
		this.GetComponent<InputField>().interactable = true;
		// Increase size to original
		this.transform.localScale = new Vector3(1, 1, 1);
		// activate Destroy Button
		destroyButton.SetActive(true);
		// deactivate the re-open Button
		editButton.SetActive(false);
		closed = false;
	}

	public bool IsClosed(){
		return closed;
	}
}
