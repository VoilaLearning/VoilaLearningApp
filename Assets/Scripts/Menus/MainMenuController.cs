using UnityEngine;
using System.Collections;

/// <summary>
/// Opens submenus
/// </summary>

[DisallowMultipleComponent]
public class MainMenuController : MonoBehaviour {

    [SerializeField] GameObject classMenu;
    [SerializeField] GameObject profileMenu;


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
