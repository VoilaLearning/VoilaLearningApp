using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Draw : MonoBehaviour
{
    private LineRenderer line;
    public bool isMousePressed;
    private List<Vector3> pointsList;
    private Vector3 mousePos;
    public static Color brushColour = Color.black;
    static int index;
    public static bool canDraw = true;
    // Structure for line points
    struct myLine
    {
        public Vector3 StartPoint;
        public Vector3 EndPoint;
    };

    void Start()
    {

        //print(index);
        index++;

        // Create line renderer component and set its property
        line = gameObject.AddComponent<LineRenderer>();
        //can change to round edges w/ custom blend
        line.material = new Material((Material)Resources.Load("Alpha Blended"));
        line.SetVertexCount(0);
        line.SetWidth(0.3f, 0.5f);
        line.SetColors(brushColour, brushColour);
        line.useWorldSpace = true;
        isMousePressed = false;
        pointsList = new List<Vector3>();
        //stack lines over each other
        line.sortingOrder = index; 
    }
    void Update()
    {
        // If mouse button down, remove old line and set its color to green
        /*foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                isMousePressed = true;
                line.SetVertexCount(0);
                pointsList.RemoveRange(0, pointsList.Count);
                line.SetColors(brushColour, brushColour);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isMousePressed = false;
                line.SetColors(brushColour, brushColour);
                Destroy(this.GetComponent<Draw>());
                GameObject.Instantiate(Resources.Load("Brush"));
            }
            // Drawing line when mouse is moving(presses)
            else if (touch.phase == TouchPhase.Moved)
            {
                Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10);
                mousePos = Camera.main.ScreenToWorldPoint(temp);
                mousePos.x *= -1;
                mousePos.y *= -1;
                mousePos.z = 0;
                if (!pointsList.Contains(mousePos))
                {
                    pointsList.Add(mousePos);
                    line.SetVertexCount(pointsList.Count);
                    line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
                }
            }
        }*/
        if(Input.GetMouseButtonDown(0) && canDraw)
        {
            isMousePressed = true;
            line.SetVertexCount(0);
            pointsList.RemoveRange(0, pointsList.Count);
            line.SetColors(brushColour, brushColour);
        }
        if(Input.GetMouseButtonUp(0) && canDraw)
        {
            isMousePressed = false;
            line.SetColors(brushColour, brushColour);
            Destroy(this.GetComponent<Draw>());
            GameObject.Instantiate(Resources.Load("Brush"));
        }
        if(isMousePressed && canDraw)
        {
            Vector3 temp = new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10);
            mousePos = Camera.main.ScreenToWorldPoint(temp);
            mousePos.x *= -1;
            mousePos.y *= -1;
            mousePos.z = 0;
            if (!pointsList.Contains(mousePos))
            {
                pointsList.Add(mousePos);
                line.SetVertexCount(pointsList.Count);
                line.SetPosition(pointsList.Count - 1, (Vector3)pointsList[pointsList.Count - 1]);
            }
        }
    }

    public void ChangeColour()
    {
        brushColour = GetComponent<ColourButton>().newBrushColour;
    }
}