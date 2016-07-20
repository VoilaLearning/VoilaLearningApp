using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class TwentyOneQsPassAndPlayGame : MonoBehaviour {

    [Header("Screens")]
    [SerializeField] GameObject categoriesScreen;
    [SerializeField] GameObject answerScreen;
    [SerializeField] GameObject resultsScreen;
    [SerializeField] GameObject endScreen;

    [Header("References")]
    [SerializeField] Text roundText;
    [SerializeField] Text turnText;
    [SerializeField] InputField inputField;

    List<string> playersQuestions = new List<string>();
    List<string> opponentsQuestions = new List<string>();
    List<string> playersAnswers = new List<string>();
    List<string> opponentsAnswers = new List<string>();

    string opponentName;
    int round;
    bool playersTurn;

    GameObject selectedCategory;
    string playersPick = "";
    string opponentsPick = "";


    void Awake () {

        round = 1;
        playersTurn = true;
        UpdateText();
        OpenScreen(categoriesScreen);
    }

    void UpdateText () {

        roundText.text = "Round " + round;
        turnText.text = (playersTurn) ? ("Dave's Turn!") : (opponentName + "'s Turn!");
        inputField.text = "";
    }

    void OpenScreen(GameObject activeScreen) {

        categoriesScreen.SetActive(false);
        answerScreen.SetActive(false);
        resultsScreen.SetActive(false);
        endScreen.SetActive(false);
        activeScreen.SetActive(true);
    }

    public void SetOpponentName (string name) {

        opponentName = name;
        name.TrimEnd(' ');
    }

    public void SetPick () {

        string pick = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

        if(playersPick == "") {

            playersPick = pick;
            SelectionText();
        }
        else {

            opponentsPick = pick;
            OpenScreen(answerScreen);
        }
    }

    public void SetCategory (GameObject category) {

        selectedCategory = category;
        SelectionText();
    }

    void SelectionText () {

        selectedCategory.GetComponentInChildren<Text>().text =
            (playersPick == "") ? "Dave's Turn:" : opponentName + "'s Turn:";
    }

    public void SendQuestion () {

        if(inputField.text != null) {

            if(playersTurn) {

                playersQuestions.Add(inputField.text);
                playersTurn = false;
            }
            else {

                opponentsQuestions.Add(inputField.text);
                playersTurn = true;
                round++;
            }

            OpenScreen(resultsScreen);
            UpdateText();
        }
    }

    public void SendAnswer (bool answer) {

        string result = (answer) ? "Yes" : "No";

        if(playersTurn) {
            
            playersAnswers.Add(result);
        }
        else {

            opponentsAnswers.Add(result);
        }

        OpenScreen(answerScreen);
    }

    public int GetRound () {

        return round;
    }

    public string GetLastQuestion () {

        string answer = (playersTurn) ? opponentsQuestions[opponentsQuestions.Count - 1] : playersQuestions[playersQuestions.Count - 1];
        return answer;
    }

    public string GetMyLastQuestion () {

        string answer = (playersTurn) ? playersQuestions[playersQuestions.Count - 1] : opponentsQuestions[opponentsQuestions.Count - 1];
        return answer;
    }

    public string GetLastAnswer () {

        string answer = (playersTurn) ? opponentsAnswers[opponentsAnswers.Count - 1] : playersAnswers[playersAnswers.Count - 1];
        return answer;
    }

    public string GetPreviousPlayerName () {

        string name = (playersTurn) ? opponentName : "Dave";
        return name;
    }

    public void SendGuess (InputField inputField) {

        string result;

        if(playersTurn) {

            result = (opponentsPick.ToUpper() == inputField.text.ToUpper()) ? "You Win!" : "You Lose...";
        }
        else {

            result = (playersPick.ToUpper() == inputField.text.ToUpper()) ? "You Win!" : "You Lose...";
        }

        OpenScreen(endScreen);
        endScreen.GetComponentInChildren<Text>().text = result;

        StopCoroutine(CloseGameDelayed());
        StartCoroutine(CloseGameDelayed());
    }

    IEnumerator CloseGameDelayed () {
        
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
}
