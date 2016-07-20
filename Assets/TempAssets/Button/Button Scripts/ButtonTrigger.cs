using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

    public int trigger = 12;
    public ButtonAnimate buttonAnimate;


    void Start()
    {

    }


    // Triggers animations on click
    void OnMouseDown()
    {
        // TOP LEFT
        if (gameObject.tag == "button_topleft")
        {
            buttonAnimate.trigger = 0;
            buttonAnimate.forceMyPies = true;
            Debug.Log("TopLeftClick");
        }

        // TOP MIDDLE
        else if (gameObject.tag == "button_topmid")
        {
            buttonAnimate.trigger = 1;
            buttonAnimate.forceMyPies = true;
            Debug.Log("TopMidClick");
        }

        // TOP RIGHT
        else if (gameObject.tag == "button_topright")
        {
            buttonAnimate.trigger = 2;
            buttonAnimate.forceMyPies = true;
            Debug.Log("TopRightClick");
        }

        // LEFT
        else if (gameObject.tag == "button_left")
        {
            buttonAnimate.trigger = 3;
            buttonAnimate.forceMyPies = true;
            Debug.Log("LeftClick");
        }

        // MIDDLE
        else if (gameObject.tag == "button_mid")
        {
            buttonAnimate.trigger = 4;
            buttonAnimate.forceMyPies = true;
            Debug.Log("MidClick");
        }

        // RIGHT
        else if (gameObject.tag == "button_right")
        {
            buttonAnimate.trigger = 5;
            buttonAnimate.forceMyPies = true;
            Debug.Log("RightClick");
        }

        // BOTTOM LEFT
        else if (gameObject.tag == "button_botleft")
        {
            buttonAnimate.trigger = 6;
            buttonAnimate.forceMyPies = true;
            Debug.Log("BotLeftClick");
        }

        // BOTTOM MIDDLE
        else if (gameObject.tag == "button_botmid")
        {
            buttonAnimate.trigger = 7;
            buttonAnimate.forceMyPies = true;
            Debug.Log("BotMidClick");
        }

        // BOTTOM RIGHT
        else if (gameObject.tag == "button_botright")
        {
            buttonAnimate.trigger = 8;
            buttonAnimate.forceMyPies = true;
            Debug.Log("BotRightClick");

        }





    }


}
