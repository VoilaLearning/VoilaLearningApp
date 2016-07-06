using UnityEngine;
using System.Collections;

/// <summary>
/// Attached to a menu one level below the main menu
/// </summary>

[DisallowMultipleComponent]
public class SubmenuController : MonoBehaviour {

    [SerializeField] GameObject mainMenu;

    public void OpenMainMenu () {

        mainMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
