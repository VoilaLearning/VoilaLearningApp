using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// Opens submenus
/// </summary>

[DisallowMultipleComponent]
public class MainMenuController : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] float defaultIconSize = 100f;
    [SerializeField] float selectedIconSize = 135f;

    [Header("References")]
    [SerializeField] GameObject classMenu;
    [SerializeField] GameObject profileMenu;
    [SerializeField] Transform[] menuCameraPositions;
    [SerializeField] Button[] HUDButtons;

    int currentMenuIndex = 2;

    void Awake () {

        HUDButtons[currentMenuIndex].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = selectedIconSize * Vector3.one;
    }

    // Called by the HUD buttons on the canvas
    public void SetCurrentMenuIndex (int index) {

        currentMenuIndex = index;
        BoldActiveButton();
        ChangeCameraPosition();
    }

    // Called by MenuSwiping.cs
    public void ChangeCurrentMenuIndex(int amount) {

        currentMenuIndex += amount;
        if(currentMenuIndex >= menuCameraPositions.Length) { currentMenuIndex = 0; }
        else if(currentMenuIndex < 0) { currentMenuIndex = menuCameraPositions.Length - 1; }

        BoldActiveButton();
        ChangeCameraPosition();
    }

    void ChangeCameraPosition () {

        Camera.main.GetComponent<HUDCamera>().SetNewDestination(menuCameraPositions[currentMenuIndex]);
        BoldActiveButton();
    }

    public void BoldActiveButton () {

        foreach (Button button in HUDButtons) {

            button.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = defaultIconSize * Vector3.one;
        }
            
        HUDButtons[currentMenuIndex].transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = selectedIconSize * Vector3.one;
    }

    public void OpenClassMenu () {

        classMenu.SetActive(true);
        CloseMainMenu();
    }

    public void OpenProfileMenu () {

        profileMenu.SetActive(true);
        CloseMainMenu();
    }

    void CloseMainMenu () {

        StopCoroutine(DelayCloseMainMenu());
        StartCoroutine(DelayCloseMainMenu());
    }

    IEnumerator DelayCloseMainMenu () {

        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
    }
}
