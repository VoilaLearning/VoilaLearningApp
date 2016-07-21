using UnityEngine;
using System.Collections;

public class ButtonScale : MonoBehaviour {

    private float startingDistance;
    private Vector3 startingScale;
    public float distThreshold;
    public CanvasElementDrift canvasDrift;

    public Vector3 shrink = new Vector3(0,0,0);
    public Vector3 grow = new Vector3(1,1,1);



    void Start()
    {
        //Get starting distance to scale objects by, this is the control.
        startingDistance = Vector3.Distance(Camera.main.transform.position, transform.position);
        //Get starting scale of the object, in the previous version it would have scaled everything to one.
        startingScale = transform.localScale;

        canvasDrift = this.GetComponentInParent<CanvasElementDrift>();
    }

    void FixedUpdate()
    {
        //Figure out the current distance by finding the difference from starting distance
        float curDistance = Vector3.Distance(Camera.main.transform.position, transform.position) - startingDistance;
        // or was it the other way around, this code is untested!

        //SHRINK
        if (curDistance > distThreshold)
            transform.localScale = Vector3.Lerp(this.transform.localScale, shrink, Time.deltaTime * Random.Range(15f, 25f));

        //GROW
        else
            transform.localScale = Vector3.Lerp(this.transform.localScale, grow, Time.deltaTime * Random.Range(0.5f, 6f)); ;


        if (canvasDrift != null)
        {
            if (transform.localScale == new Vector3(0, 0, 0))
                canvasDrift.enabled = false;

            else
                canvasDrift.enabled = true;
        }

    }
}