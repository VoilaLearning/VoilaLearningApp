using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// Responsible for the movement of the camera as it moves from canvas to canvas
/// </summary>

[DisallowMultipleComponent]
public class HUDController : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] float cameraMoveSpeed;
    [SerializeField] float cameraRotationSpeed;

    [Header("References")]
    [SerializeField] Button[] HUDButtons;

    Transform destination;


    void Start () {

        destination = Camera.main.transform;
        HUDButtons[0].GetComponentInChildren<Text>().fontStyle = FontStyle.Bold;
    }

    void Update () {

        if(Vector3.Distance(Camera.main.transform.position, destination.position) > 0.5f) {
            
            Camera.main.transform.position = Vector3.Slerp(Camera.main.transform.position, destination.position, cameraMoveSpeed * Time.deltaTime);
        }

        if(Vector3.Angle(Camera.main.transform.forward, destination.forward) > 1) {

            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, destination.rotation, Time.deltaTime * cameraRotationSpeed);
        }
    }

    // Called by the buttons on the bottom panel of the HUD Canvas
    public void SetNewDestination (Transform newDestination) {

        BoldActiveButton();
        destination = newDestination;
        //Camera.main.transform.eulerAngles = newDestination.eulerAngles;
    }

    void BoldActiveButton () {

        foreach (Button button in HUDButtons) {

            button.GetComponentInChildren<Text>().fontStyle = FontStyle.Normal;
        }

        EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().fontStyle = FontStyle.Bold;
    }
}
