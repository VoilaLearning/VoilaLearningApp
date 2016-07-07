using UnityEngine;
using System.Collections;

public class MenuMover : MonoBehaviour {

	[SerializeField] float closetSpeed;

	[SerializeField] Vector3 hiddenPos;
	[SerializeField] Vector3 shownPos;

	Vector3 destination;

	void Update (){
	
		MoveMenu ();
	}

	void MoveMenu(){
		if (Vector3.Distance (this.GetComponent<RectTransform> ().localPosition, destination) > 1.5f) {
			this.GetComponent<RectTransform> ().localPosition = Vector3.Slerp (this.GetComponent<RectTransform> ().localPosition, destination, closetSpeed * Time.deltaTime);
		} else { 
			if (destination == hiddenPos) {
				this.gameObject.SetActive (false);
			}
		}
	}

	public void OpenCanvas(){
		destination = shownPos;
	}

	public void CloseCanvas(){
		destination = hiddenPos;
	}
}
