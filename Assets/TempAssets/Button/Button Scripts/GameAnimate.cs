using UnityEngine;
using System.Collections;

public class GameAnimate : MonoBehaviour
{

    public Animator anim;
    public bool forceMyPies = false;
    public int trigger = 10;

    public GameObject touchZoneFront;
    public GameObject touchZoneBack;
    public GameObject touchZonePlay;







    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        touchZoneBack.SetActive(false);
        touchZonePlay.SetActive(false);
    }


    void Update()
    {
        {

            // GAME FLIP
            if (trigger == 1 && forceMyPies == true)
            {
                touchZoneFront.SetActive(false);
                touchZoneBack.SetActive(true);
                touchZonePlay.SetActive(true);


                anim.Play("GameFlip", -1, 0f);
                forceMyPies = false;
            }



            // GAME REVERSE
            else if (trigger == 2 && forceMyPies == true)
            {
                touchZoneFront.SetActive(true);
                touchZoneBack.SetActive(false);
                touchZonePlay.SetActive(false);


                anim.Play("GameReverse", -1, 0f);
                forceMyPies = false;
            }



            // GAME SPIN
            else if (trigger == 3 && forceMyPies == true)
            {
                //anim.Play("GameSpin", -1, 0f);
                forceMyPies = false;

            }


        }

    }
}
