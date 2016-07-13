using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class MenuSwiping : MonoBehaviour {

    Vector2 touchStartPosition;
    Vector2 touchEndPosition;


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

            this.GetComponent<MainMenuController>().ChangeCurrentMenuIndex(-1);

        }
        else if(deltaPosition.x < -0.3f * Screen.width) { // R to L

            this.GetComponent<MainMenuController>().ChangeCurrentMenuIndex(1);
        }
    }
}
