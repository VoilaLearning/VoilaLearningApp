using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// Handles displaying other students' stats and the search functionality
/// from the input field
/// </summary>

[DisallowMultipleComponent]
public class StudentsCanvasController : MonoBehaviour {

    [SerializeField] GameObject studentStatsCanvas;
    [SerializeField] Transform scrollViewContent;

	// Called when user clicks on a student in the scroll view list
    public void OpenStudentStatsCanvas () {

        studentStatsCanvas.SetActive(true);
        Text nameText = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>();
        studentStatsCanvas.transform.FindChild("Name Text").GetComponent<Text>().text = nameText.text;
    }

    // Called when using the input field search tool
    public void UpdateList(string input) {

        scrollViewContent.SetAllChildrenActive();

        int totalChildren = scrollViewContent.childCount;

        if(input != "") {
            
            // Show only matching students
            for (int i = 0; i < totalChildren; i++) {

                if (!scrollViewContent.GetChild(i).GetComponentInChildren<Text>().text.Contains(input)) {

                    scrollViewContent.GetChild(i).gameObject.SetActive(false);
                }
            }
        }

        AdjustContentHeight();
    }

    void AdjustContentHeight () {

        float contentWidth = scrollViewContent.GetComponent<RectTransform>().sizeDelta.x;
        float contentHeight = scrollViewContent.GetActiveChildCount() * 175;
        scrollViewContent.GetComponent<RectTransform>().sizeDelta = new Vector2(contentWidth, contentHeight);
    }
}
