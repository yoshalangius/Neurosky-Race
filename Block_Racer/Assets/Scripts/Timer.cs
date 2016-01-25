using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public int second = 0;
    public GameObject Wall;
    private static int Steady;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Debug.Log(second);
        Steady = CheckPoints.Lap;
        if (second != 100)
        {
            second = second + 1;
        }
        else
        {
            Wall.SetActive(false);

        }

        if (Steady == 4)
        {
            Wall.SetActive(true);
        }
	}
}
