using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour {

	[SerializeField] GameObject destroyButton;
	[SerializeField] GameObject editButton;

	Color activeColor = Color.white;
	Color inactiveColor = Color.black;

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
		Debug.Log ("Input Edited");
		// Make it no longer interractable
		this.GetComponent<InputField>().interactable = false;
		// Shrink Box Down 0.5, 0.5, 0.5
		this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		// Deactivate Destroy Button
		destroyButton.SetActive(false);
		// Activate the re-open Button
		editButton.SetActive(true);
		// Change Color of input field?? 
	}

	public void OpenInputField(){
		// Make it interractable
		this.GetComponent<InputField>().interactable = true;
		// Increase size to original
		this.transform.localScale = new Vector3(1, 1, 1);
		// activate Destroy Button
		destroyButton.SetActive(true);
		// deactivate the re-open Button
		editButton.SetActive(false);
		// Change Color of input field?? 
	}
}
