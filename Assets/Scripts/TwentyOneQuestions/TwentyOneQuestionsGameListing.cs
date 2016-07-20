using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Handles the parameters of a game in the listing for current games
/// </summary>

// TODO:
// Move data from controller script to here for better handling with game script

[DisallowMultipleComponent]
public class TwentyOneQuestionsGameListing : MonoBehaviour {

    [SerializeField] Text nameText;
    [SerializeField] Text statusText;
    [SerializeField] Text questionCountText;

	
    public void SetName (string newName) {

        nameText.text = newName; 
    }

    public void SetStatus () {

        // ???
    }

    public void SetQuestionCount (int questionNumber) {

        questionCountText.text = "Q's\n" + questionNumber + " / 21";
    }
}
