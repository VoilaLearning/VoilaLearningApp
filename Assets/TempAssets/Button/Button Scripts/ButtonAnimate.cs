using UnityEngine;
using System.Collections;

public class ButtonAnimate : MonoBehaviour {


    public Animator anim;

    public bool forceMyPies = false;

    public int trigger = 10;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }


    // Triggers animations on click
    void Update()
    {
        // TOP LEFT
        if (trigger == 0 && forceMyPies == true)
        {
            anim.Play("TopLeftClick", -1, 0f);
            forceMyPies = false;

        }

        // TOP MIDDLE
        else if (trigger == 1 && forceMyPies == true)
        {
            anim.Play("TopMidClick", -1, 0f);
            forceMyPies = false;
        }

        // TOP RIGHT
        else if (trigger == 2 && forceMyPies == true)
        {
            anim.Play("TopRightClick", -1, 0f);
            forceMyPies = false;

        }

        // LEFT
        else if (trigger == 3 && forceMyPies == true)
        {
            anim.Play("LeftClick", -1, 0f);
            forceMyPies = false;

        }

        // MIDDLE
        else if (trigger == 4 && forceMyPies == true)
        {
            anim.Play("MidClick", -1, 0f);
            forceMyPies = false;

        }

        // RIGHT
        else if (trigger == 5 && forceMyPies == true)
        {
            anim.Play("RightClick", -1, 0f);
            forceMyPies = false;

        }

        // BOTTOM LEFT
        else if (trigger == 6 && forceMyPies == true)
        {
            anim.Play("BotLeftClick", -1, 0f);
            forceMyPies = false;

        }

        // BOTTOM MIDDLE
        else if (trigger == 7 && forceMyPies == true)
        {
            anim.Play("BotMidClick", -1, 0f);
            forceMyPies = false;

        }

        // BOTTOM RIGHT
        else if (trigger == 8 && forceMyPies == true)
        {
            anim.Play("BotRightClick", -1, 0f);
            forceMyPies = false;

        }

        // GAME FLIP
        else if (trigger == 9 && forceMyPies == true)
        {
            anim.Play("GameFlip", -1, 0f);
            forceMyPies = false;

        }

        // GAME Reverse
        else if (trigger == 10 && forceMyPies == true)
        {
            anim.Play("GameReverse", -1, 0f);
            forceMyPies = false;

        }

    }


}
