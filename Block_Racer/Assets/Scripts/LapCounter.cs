using UnityEngine;
using System.Collections;

public class LapCounter : MonoBehaviour
{
    TextMesh Counter;
    private static int LapsCounted;
    

	// Use this for initialization
	void Start ()
    {
        Counter = GetComponent<TextMesh>();

        
	}
	
	// Update is called once per frame
	void Update ()
    {
        LapsCounted = CheckPoints.Lap;
        Counter.text = "Lap: " + LapsCounted;
        
    }
}
