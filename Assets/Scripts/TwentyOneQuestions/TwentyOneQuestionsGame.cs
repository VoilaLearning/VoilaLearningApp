using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public enum GameState { Initiating, ReplyReceived, ReplyNeeded, ReplySent, NumberOfGameStates }

[DisallowMultipleComponent]
public class TwentyOneQuestionsGame : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] GameState gameState;
    [SerializeField] string opponentName;
    [SerializeField] int round = 0;

    [Header("Screens")]
    [SerializeField] GameObject challengeSentScreen;
    [SerializeField] GameObject resultsScreen;
    [SerializeField] GameObject sendScreen;
    [SerializeField] GameObject sentScreen;

    [Header("References")]
    [SerializeField] Text roundText;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;
    [SerializeField] GameObject sentMessage;

    TwentyOneQuestionsGameListing gameListing;
    bool playersTurn = false;


    void OnEnable () {

        CloseScreens();
        OpenAppropriateScreen();
    }

    void OpenAppropriateScreen () {

        switch (gameState) {
            case GameState.Initiating:
                challengeSentScreen.SetActive(true);
                break;
            case GameState.ReplyReceived:
                resultsScreen.SetActive(true);
                break;
            case GameState.ReplyNeeded:
                sendScreen.SetActive(true);
                break;
            case GameState.ReplySent:
                sentScreen.SetActive(true);
                break;
        }

        roundText.text = "Round " + round.ToString("0");
    }

    void CloseScreens () {

        challengeSentScreen.SetActive(false);
        sendScreen.SetActive(false);
        sentScreen.SetActive(false);
        resultsScreen.SetActive(false);
    }

    public void SendYes () {

        sentMessage.SetActive(true);
        StopCoroutine("CloseGame");
        StartCoroutine("CloseGame");
    }

    public void SendNo () {

        sentMessage.SetActive(true);
        StopCoroutine("CloseGame");
        StartCoroutine("CloseGame");
    }

    IEnumerator CloseGame () {

        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
        playersTurn = false;
        gameState = GameState.ReplySent;
    }

    public bool IsPlayersTurn () {

        return playersTurn;
    }

    public void SetPlayersTurn (bool turn) {

        playersTurn = turn;
    }

    public int GetRound () {

        return round;
    }

    public string GetOpponentName () {

        return opponentName;
    }

    public void SetOpponentName (string name) {

        opponentName = name;
    }
}
