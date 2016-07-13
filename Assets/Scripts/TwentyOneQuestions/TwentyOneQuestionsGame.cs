using UnityEngine;
using UnityEngine.UI;
using System.Collections;


[DisallowMultipleComponent]
public class TwentyOneQuestionsGame : MonoBehaviour {

    [SerializeField] Button yesButton;
    [SerializeField] Button noButton;
    [SerializeField] GameObject sentMessage;
    bool playersTurn = true;

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
}
