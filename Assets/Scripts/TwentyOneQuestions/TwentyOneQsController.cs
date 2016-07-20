using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class TwentyOneQsController : MonoBehaviour {

    [SerializeField] GameObject gamePrefab;
    [SerializeField] Transform gameParent;


    public void CreateNewGame (Text opponentName) {

        GameObject newGame = Instantiate(gamePrefab, Vector3.zero, Quaternion.identity) as GameObject;
        newGame.transform.SetParent(gameParent, false);

        // Change gameobject name
        int numberOfGames = gameParent.childCount;
        newGame.name = "Game with " + opponentName.text;

        // Transfer data to game script
        newGame.GetComponent<TwentyOneQsPassAndPlayGame>().SetOpponentName(opponentName.text);
    }
}
