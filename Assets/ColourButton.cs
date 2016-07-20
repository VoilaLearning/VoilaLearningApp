using UnityEngine;
using System.Collections;

public class ColourButton : MonoBehaviour {
    public Color newBrushColour;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeColour()
    {
        Draw.brushColour = newBrushColour;
    }
}
