using UnityEngine;
using System.Collections;

public class GameTransform : MonoBehaviour {

    public float smooth = 2;

    public Vector3 startingPosition;
    public Vector3 moveTo;



    void Start () {
	
	}

    void OnMouseDown()
    {

        // GAME FLIP
        if (gameObject.tag == "game_flip")
        {
            transform.position = Vector3.Lerp(startingPosition, moveTo, Time.deltaTime * smooth);

            Debug.Log("Transform");
        }

        // GAME FLIP
        else if (gameObject.tag == "game_reverse")
        {

        }

        // GAME SPIN
        else if (gameObject.tag == "game_spin")
        {


        }




    }
}
