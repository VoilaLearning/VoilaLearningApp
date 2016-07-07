using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
///  
/// </summary>

[DisallowMultipleComponent]
public class MessageBoardController : MonoBehaviour {

    [SerializeField] GameObject inputFieldPrefab;
    [SerializeField] GameObject scrollViewContent;

    public void WritePost () {

        GameObject newInputField = Instantiate(inputFieldPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        newInputField.transform.SetParent(scrollViewContent.transform);
        newInputField.GetComponent<RectTransform>().localPosition = Vector3.zero;
        newInputField.GetComponent<RectTransform>().localRotation = Quaternion.identity;
        newInputField.GetComponent<RectTransform>().localScale = Vector3.one;

        ResizeContentField();

        //#if UNITY_IOS || UNITY_ANDROID
        InputField inputField = newInputField.GetComponentInChildren<InputField>();
        inputField.ActivateInputField();
        //TouchScreenKeyboard.Open("");
        //#endif
    }

    void ResizeContentField () {
        
        float inputFieldHeight = inputFieldPrefab.GetComponent<RectTransform>().sizeDelta.y;
        int contentChildCount = scrollViewContent.transform.childCount;
        float currentContentWidth = scrollViewContent.GetComponent<RectTransform>().sizeDelta.x;
        float newContentHeight = contentChildCount * inputFieldHeight;

        scrollViewContent.GetComponent<RectTransform>().sizeDelta = new Vector2(currentContentWidth, newContentHeight);
    }
}
