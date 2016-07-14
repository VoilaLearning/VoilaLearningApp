using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[DisallowMultipleComponent]
public class TwentyOneQuestionsGame : MonoBehaviour {

    [Header("Parameters")]
    [SerializeField] string opponentName;
    [SerializeField] int round = 0;

    [Header("References")]
    [SerializeField] Text roundText;
    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;
    [SerializeField] GameObject sentMessage;

    bool playersTurn = false;


    void OnEnable () {

        UpdateState();
    }

    public void UpdateState () {

        roundText.text = "Round " + round.ToString("0");
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
