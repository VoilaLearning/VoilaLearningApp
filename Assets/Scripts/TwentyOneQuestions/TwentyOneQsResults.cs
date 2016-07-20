using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TwentyOneQsResults : MonoBehaviour {

    [SerializeField] Text myLastQuestionText;
    [SerializeField] Text playerAnswerLabel;
    [SerializeField] Text playerAnsweredText;
    [SerializeField] Text playerQuestionLabel;
    [SerializeField] Text currentQuestionText;

    TwentyOneQsPassAndPlayGame gameController;


    void OnEnable () {

        gameController = this.GetComponentInParent<TwentyOneQsPassAndPlayGame>();

        string lastPlayersName = gameController.GetPreviousPlayerName();
        playerAnswerLabel.text = lastPlayersName + " Answered...";
        playerQuestionLabel.text = lastPlayersName + " Asked...";
        FillInPreviousRoundInfo();
    }

    void FillInPreviousRoundInfo () {

        if(gameController.GetRound() == 1) {

            for(int i = 0; i < 4; i++) {

                this.transform.GetChild(i).gameObject.SetActive(false);
            }

            currentQuestionText.text = gameController.GetLastQuestion();
        }
        else {

            if (this.transform.GetChild(0).gameObject.activeSelf == false) {

                for (int i = 0; i < 4; i++) {

                    this.transform.GetChild(i).gameObject.SetActive(true);
                }
            }
                
            myLastQuestionText.text = gameController.GetMyLastQuestion();
            playerAnsweredText.text = gameController.GetLastAnswer();
            currentQuestionText.text = gameController.GetLastQuestion();
        }
    }
}
