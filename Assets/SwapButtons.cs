using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SwapButtons : MonoBehaviour {
    public static GameObject tempBrush;
    public GameObject gameManager;
    public static InputField inputField;
    public static Text text;
    // Use this for initialization
    void Start ()
    {
        inputField = Canvas.FindObjectOfType<InputField>();
        text = GameObject.FindGameObjectWithTag("Guess").GetComponent<Text>();
        gameManager = GameObject.FindGameObjectWithTag("Game_Manager");
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void boizInDaHood()
    {
        GameObject tempGameObject;
        tempGameObject = GameObject.FindGameObjectWithTag("Brush");
        Draw.canDraw = !Draw.canDraw;
    }

    public void boizOutDaHood()
    {

        GameObject[] brushObjects;
        brushObjects = GameObject.FindGameObjectsWithTag("Brush");
        foreach (GameObject gObject in brushObjects)
        {
            gObject.SetActive(false);
        }
        tempBrush = (GameObject)GameObject.Instantiate(Resources.Load("Brush"));
        Draw.canDraw = !Draw.canDraw;
        text.text = inputField.text;
        gameManager.GetComponent<GameManager>().guesses.Add(inputField.text);
        gameManager.GetComponent<GameManager>().currentTurn++;
        
    }
}
