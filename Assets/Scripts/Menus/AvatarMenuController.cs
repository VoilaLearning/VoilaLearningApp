using UnityEngine;
using System.Collections;

public class AvatarMenuController : MonoBehaviour {

	[SerializeField] GameObject closetCanvas;
	[SerializeField] float closetSpeed;

	[SerializeField] Vector3 hiddenPos;
	[SerializeField] Vector3 shownPos;

	Vector3 destination;

	// Use this for initialization
	void Start () {
		destination = hiddenPos;
	}
	
	// Update is called once per frame
	void Update () {
		MoveCloset ();
	}

	void MoveCloset(){
		if (Vector3.Distance (this.closetCanvas.GetComponent<RectTransform>().localPosition, destination) > 0.01f) {
			this.closetCanvas.GetComponent<RectTransform>().localPosition = Vector3.Slerp (this.closetCanvas.GetComponent<RectTransform>().localPosition, destination, closetSpeed * Time.deltaTime);
		}
	}

	public void OpenClosetCanvas(){
		destination = shownPos;
	}

	public void CloseClosetCanvas(){
		destination = hiddenPos;
	}
}
