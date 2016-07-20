using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player2GuessHider : MonoBehaviour {
    public Text text;
    public GameObject gameManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void HidePrompt()
    {
        if (gameManager.GetComponent<GameManager>().currentTurn > gameManager.GetComponent<GameManager>().amountOfTurns)
        {
            text.gameObject.SetActive(false);
        }
    }
}
