using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class TwentyOneQuestionsController : MonoBehaviour {

    [Header("Current Game Stuff")]
    [SerializeField] GameObject gameListingPrefab;
    [SerializeField] Transform gameLobbyParent;

    [Header("New Game Stuff")]
    [SerializeField] GameObject gamePrefab;
    [SerializeField] Transform gameParent;
	
    GameObject[] activeGamesArray;
    List<GameObject> activeGamesList = new List<GameObject>();


    public void CreateNewGame (Text opponentName) {

        GameObject newGame = Instantiate(gamePrefab, Vector3.zero, Quaternion.identity) as GameObject;
        newGame.transform.SetParent(gameParent, false);
        activeGamesList.Add(newGame);

        // Change gameobject name
        int numberOfGames = gameParent.childCount;
        newGame.name = "Game with " + opponentName.text;

        // Transfer data to game script
        newGame.GetComponent<TwentyOneQuestionsGame>().SetOpponentName(opponentName.text);

        AddGameToLobby(newGame);
    }

    public void AddGameToLobby (GameObject game) {

        GameObject newGameListing = Instantiate(gameListingPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        newGameListing.transform.SetParent(gameLobbyParent, false);

        // Resize parent
        int childCount = gameLobbyParent.transform.childCount;
        float gameLobbyWidth = gameLobbyParent.GetComponent<RectTransform>().sizeDelta.x;
        float gameLobbyHeight = childCount * gameListingPrefab.GetComponent<RectTransform>().sizeDelta.y;
        gameLobbyParent.GetComponent<RectTransform>().sizeDelta = new Vector2(gameLobbyWidth, gameLobbyHeight);

        // Set avatar

        // Set name
        string opponentName = game.GetComponent<TwentyOneQuestionsGame>().GetOpponentName();
        newGameListing.transform.GetChild(2).GetComponent<Text>().text = opponentName;

        // Set status
        bool isPlayersTurn = game.GetComponent<TwentyOneQuestionsGame>().IsPlayersTurn();
        string status = isPlayersTurn ? "Your Turn!" : "Waiting on Response";
        Color textColor = isPlayersTurn ? Color.green : Color.black;
        newGameListing.transform.GetChild(3).GetComponent<Text>().text = "Status: " + status;
        newGameListing.transform.GetChild(3).GetComponent<Text>().color = textColor;

        // Set question number
        int roundNumber = game.GetComponent<TwentyOneQuestionsGame>().GetRound();
        newGameListing.transform.GetChild(4).GetComponent<Text>().text = "Q's\n" + roundNumber + "/21";

        // Set a reference from the game to the listing

    }
}
