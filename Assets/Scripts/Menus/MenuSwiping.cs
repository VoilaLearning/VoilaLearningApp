using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class MenuSwiping : MonoBehaviour {

    [SerializeField] Transform[] menuCameraPositions;
    [SerializeField] Text tempText;

    Vector2 touchStartPosition;
    Vector2 touchEndPosition;
    int currentMenuIndex = 2;

    void Update () {

        if(Input.touchCount == 1) {

            switch (Input.GetTouch(0).phase) {

                case TouchPhase.Began:
                    touchStartPosition = Input.GetTouch(0).position;
                    break;
                case TouchPhase.Ended:
                    touchEndPosition = Input.GetTouch(0).position;
                    ProcessSwipe();
                    break;
            }
        }
    }

    void ProcessSwipe () {

        Vector2 deltaPosition = touchEndPosition - touchStartPosition;

        if(deltaPosition.x > 0.3f * Screen.width) { // L to R

            currentMenuIndex--;
            if(currentMenuIndex < 0) { currentMenuIndex = menuCameraPositions.Length - 1; }
            MoveCamera();
        }
        else if(deltaPosition.x < -0.3f * Screen.width) { // R to L
            
            currentMenuIndex++;
            if(currentMenuIndex >= menuCameraPositions.Length) { currentMenuIndex = 0; }
            MoveCamera();
        }
    }

    void MoveCamera () {

        Camera.main.GetComponent<HUDCamera>().SetNewDestination(menuCameraPositions[currentMenuIndex].transform);
    }
}
