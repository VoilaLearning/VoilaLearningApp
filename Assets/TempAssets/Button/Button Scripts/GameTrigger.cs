using UnityEngine;
using System.Collections;

public class GameTrigger : MonoBehaviour {
    
    public int trigger = 12;
    public GameAnimate gameAnimate;


    void Start()
    {
	
	}

    void OnMouseDown()
    { 
	
        // GAME FLIP
        if (gameObject.tag == "game_flip")
        {
            gameAnimate.trigger = 1;
            gameAnimate.forceMyPies = true;
            Debug.Log("Flip");
        }

        // GAME REVERSE
        else if (gameObject.tag == "game_reverse")
        {
            gameAnimate.trigger = 2;
            gameAnimate.forceMyPies = true;
            Debug.Log("Reverse");
        }

        // GAME SPIN
        else if (gameObject.tag == "game_spin")
        {
            gameAnimate.trigger = 3;
            gameAnimate.forceMyPies = true;
            Debug.Log("PLAAY GAME");
        }

    }
}
