using UnityEngine;

[DisallowMultipleComponent]
public class HUDCamera : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] float cameraMoveSpeed;
    [SerializeField] float cameraRotationSpeed;

    [Header("References")]
    [SerializeField] GameObject mainMenu;

    Transform destination;

    void Start () {

        destination = Camera.main.transform;
    }

    void Update () {

        if(Vector3.Distance(Camera.main.transform.position, destination.position) > 0.5f) {

            Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, destination.position, cameraMoveSpeed * Time.deltaTime);
        }

        if(Vector3.Angle(Camera.main.transform.forward, destination.forward) > 1) {

            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, destination.rotation, Time.deltaTime * cameraRotationSpeed);
        }
    }

    // Called by MainMenuController.cs
    public void SetNewDestination (Transform newDestination) {

        if (mainMenu.activeSelf) { mainMenu.GetComponent<MainMenuController>().BoldActiveButton(); }
        destination = newDestination;
    }
}
