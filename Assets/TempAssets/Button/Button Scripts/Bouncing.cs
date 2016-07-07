using UnityEngine;
using System.Collections;

public class Bouncing : MonoBehaviour 
{
    public float amplitude;          //Set in Inspector 
    public float speed;                  //Set in Inspector 
    private float tempValy;

    private Vector3 tempPos;
    Quaternion originalRotation;

    public float amplitudeTilt;
    public float speedTilt;
    float randomStart = 0;

    void Start()
    {
        //Setup initial
        tempValy = transform.position.y;


        originalRotation = this.transform.rotation;
        randomStart = Random.Range(0, 20f);
    }

    void Update()
    {
        Bob();
        Tilt();
    }

    void Bob()
    {
        tempPos.y = tempValy + amplitude * Mathf.Sin(speed * (Time.time + randomStart));
        transform.position = new Vector3(this.transform.position.x, tempPos.y, this.transform.position.z);
    }

 

    void Tilt()
    {
        float tiltAmount = amplitudeTilt * Mathf.Sin(speedTilt * (Time.time + randomStart));
        Quaternion newRotation = originalRotation * Quaternion.Euler(0f, 0f, tiltAmount);

        this.transform.rotation = newRotation;
    }


}
