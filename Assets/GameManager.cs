using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<string> prompts = new List<string>();
    public uint amountOfTurns;
    public uint currentTurn;
    public List<string> guesses = new List<string>();
    public List<GameObject> brushes = new List<GameObject>();
    public int attemptID;
    bool showSwatches;
    public Text endGuess;
    public bool showingDrawing = false;
    public bool isDrawingTurn = true;
    public bool gameOver;

    public Text attemptText;
    public Text beginningPromptText;
    public Button sendPhoto;
    public Button nextButton;
    public Button prevButton;
    public Button continueButton;
    public Button redButton;
    public Button greenButton;
    public Button blueButton;
    public Button blackButton;
    public bool doneTextCheck;
    // Use this for initialization
    void Start()
    {
        //attemptText = GameObject.FindGameObjectWithTag("EndGuess").GetComponent<Text>();
        beginningPromptText.text = "Draw a " + prompts[(int)Random.Range(0, 4)] + "!";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeTurns()
    {

        beginningPromptText.gameObject.SetActive(false);
        if (!showSwatches)
        {
            redButton.gameObject.SetActive(false);
            greenButton.gameObject.SetActive(false);
            blueButton.gameObject.SetActive(false);
            blackButton.gameObject.SetActive(false);
            showSwatches = !showSwatches;
            Draw.canDraw = false;
        }
        else if (showSwatches && (currentTurn <= amountOfTurns))
        {
            redButton.gameObject.SetActive(true);
            greenButton.gameObject.SetActive(true);
            blueButton.gameObject.SetActive(true);
            blackButton.gameObject.SetActive(true);
            showSwatches = !showSwatches;
        }

        if (isDrawingTurn)
        {
            //Add brushes to the array of brushes

            foreach (GameObject brush in GameObject.FindGameObjectsWithTag("Brush"))
            {
                if (brush.GetComponent<Brush>().turnID == currentTurn)
                {
                    brushes.Add(brush);
                }
            }
            isDrawingTurn = false;
        }
        else
        {
            //Add guess to the array of guesses
            //guesses.Add(Canvas.FindObjectOfType<InputField>().text);
            currentTurn++;

            isDrawingTurn = true;


        }

        if (currentTurn > amountOfTurns)//If max turns are reached
        {
            //We'll get to this
            gameOver = true;
            sendPhoto.gameObject.SetActive(false);
            //Debug.Log(attemptText);
            attemptText.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(true);
            //nextButton.gameObject.SetActive(true);
            Draw.canDraw = false;
        }
        else
        {
            isDrawingTurn = !isDrawingTurn;
        }
    }
    public void showDrawing()
    {
        foreach (GameObject attemptBrush in brushes)
        {
            if (attemptBrush.GetComponent<Brush>().turnID == attemptID)
            {
                attemptBrush.SetActive(true);
            }
        }
    }
    public void showNext()
    {
        if (showingDrawing)
        {
            showingDrawing = false;
            foreach (GameObject attemptBrush in brushes)
            {
                attemptBrush.SetActive(false);
            }

            attemptText.gameObject.SetActive(true);
            attemptText.text = guesses[attemptID];
            if (attemptID == 0 && !showingDrawing)
            {
                prevButton.gameObject.SetActive(true);
            }
            else if (attemptID == 4 && !showingDrawing)
            {
                //Application.LoadLevel("MainMenu");
            }
        }
        else
        {
            showingDrawing = true;
            attemptID++;
            foreach (GameObject attemptBrush in brushes)
            {
                if (attemptBrush.GetComponent<Brush>().turnID == attemptID)
                {
                    attemptBrush.SetActive(true);
                }
            }

            attemptText.text = guesses[attemptID];
            attemptText.gameObject.SetActive(false);
        }
    }

    public void showPrev()
    {
        if (showingDrawing)
        {
            showingDrawing = false;
            attemptID--;
            foreach (GameObject attemptBrush in brushes)
            {
                attemptBrush.SetActive(false);
            }
            attemptText.text = guesses[attemptID];
            attemptText.gameObject.SetActive(true);

        }
        else
        {
            showingDrawing = true;
            foreach (GameObject attemptBrush in brushes)
            {
                if (attemptBrush.GetComponent<Brush>().turnID == attemptID)
                {
                    attemptBrush.SetActive(true);
                }
            }
            attemptText.text = guesses[attemptID];
            attemptText.gameObject.SetActive(false);
        }
    }
}
