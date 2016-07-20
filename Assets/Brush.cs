using UnityEngine;
using System.Collections;

public class Brush : MonoBehaviour {
    public uint turnID = 0;
    public GameObject gameManager;
	// Use this for initialization
	void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("Game_Manager");
        turnID = gameManager.GetComponent<GameManager>().currentTurn;
	}
	
	// Update is called once per frame
	void Update ()
    {

	}
}
