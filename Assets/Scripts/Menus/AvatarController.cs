using UnityEngine;
using System.Collections;

public class AvatarController : MonoBehaviour {

	[SerializeField] float avatarMoveSpeed;
	Transform destination;

	// Use this for initialization
	void Start () {
		destination = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
		CenterAvatarToCurrentMenu ();
	}

	public void CenterAvatarToCurrentMenu(){

		if (Vector3.Distance (this.transform.position, destination.position) > 0.5f) {		
			// Move the Avatar towards the camera
			this.transform.position = Vector3.Slerp(this.transform.position, destination.position, avatarMoveSpeed * Time.deltaTime);
		}

		if (Vector3.Angle (this.transform.forward, destination.forward) > 1) {
			// Rotate the avatar towards the camera
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, destination.rotation, Time.deltaTime * avatarMoveSpeed);
		}
	}

	public void MoveTo(Transform newDestination){
	
		destination = newDestination;
	}
}
