using UnityEngine;
using System.Collections;

public class GradientFade : MonoBehaviour
{

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float speed = 5.0f;
    public float threshold = float.Epsilon;

    public bool faded = false;

    public SpriteRenderer sprite;

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (Input.GetKey("1"))
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(sprite.color.a, maximum, step));
            if (Mathf.Abs(maximum - sprite.color.a) <= threshold)
                faded = false;

        }
        if (Input.GetKeyDown("2"))
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Mathf.Lerp(sprite.color.a, minimum, step));
            if (Mathf.Abs(sprite.color.a - minimum) <= threshold)
                faded = true;
        }
    }

}