using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIText : MonoBehaviour {

    [Header("Profile UI Elements")]
    [SerializeField] Text profileHeaderUI;
    [SerializeField] Text avatarButtonUI;
    [SerializeField] Text settingsButtonUI;
    [SerializeField] Text accountButtonUI;

    [Header("Classroom UI Elements")]
    [SerializeField] Text classHeaderUI;
    [SerializeField] Text messageBoardButtonUI;
    [SerializeField] Text statsButtonUI;
    [SerializeField] Text studentsButtonUI;

    [Header("Ask A Tutor UI Elements")]
    [SerializeField] Text tutorHeaderUI;
    [SerializeField] Text callTutorButtonUI;
    [SerializeField] Text textTutorButtonUI;
	
    [Header("Games UI Elements")]
    [SerializeField] Text gamesHeaderUI;
    [SerializeField] Text[] gameButtonUI;

    [Header("Classroom UI Elements")]
    [SerializeField] Text challengeUI1;
    [SerializeField] Text challengeUI2;
    [SerializeField] Text notificationsUI1;
    [SerializeField] Text notificationsUI2;

    // Setters
    public void SetProfileHeaderUI(string newText) { profileHeaderUI.text = newText; }
    public void SetAvatatButtonUI(string newText) { avatarButtonUI.text = newText; }
    public void SetSettingButtonUI(string newText) { settingsButtonUI.text = newText; }
    public void SetAccuontButtonUI(string newText) { accountButtonUI.text = newText; }

    public void SetClassroomHeaderUI(string newText) { classHeaderUI.text = newText; }
    public void SetMessageBoardButtonUI(string newText) { messageBoardButtonUI.text = newText; }
    public void SetStatsButtonUI(string newText) { statsButtonUI.text = newText; }
    public void SetStudentsButtonUI(string newText) { studentsButtonUI.text = newText; }

    public void SetTutorHeaderUI(string newText) { classHeaderUI.text = newText; }
    public void SetCallTutorButtonUI(string newText) { callTutorButtonUI.text = newText; }
    public void SetTextTutorButtonUI(string newText) { textTutorButtonUI.text = newText; }
}
