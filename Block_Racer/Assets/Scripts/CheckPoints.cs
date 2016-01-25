using UnityEngine;
using System.Collections;

public class CheckPoints : MonoBehaviour
{
    public static int Lap = 0;
    public bool first = false;
    public int LapRed = 0;
    public int LapYel = 0;
    public int LapPur = 0;


    void OnTriggerEnter(Collider other)
    {
        if (Lap != 4)
        {
            if (other.gameObject.tag == "Player")
            {
                Lap = Lap + 1;
            }
        }
        else
        {
            Application.LoadLevel("GreyWin");
            Lap = 0;
        }

        if (LapRed != 4)
        {
            if (other.gameObject.tag == "Red")
            {
                LapRed = LapRed + 1;
            }
        }
        else
        {
            Application.LoadLevel("RedWin");
            Lap = 0;
        }

        if (LapYel != 4)
        {
            if (other.gameObject.tag == "Yellow")
            {
                LapYel = LapYel + 1;
            }
        }
        else
        {
            Application.LoadLevel("YellowWin");
            Lap = 0;
        }

        if (LapPur != 4)
        {
            if (other.gameObject.tag == "Purple")
            {
                LapPur = LapPur + 1;
            }
        }
        else
        {
            Application.LoadLevel("PurpleWin");
            Lap = 0;
        }

    }
    void Update()
    {
        Debug.Log(Lap);
    }

    /*static Transform playerTransform; //Store the player transform
    CarCheckPoint carCheckpoint;

    void Start()
    {

        CarCheckPoint carCheckpoint;
        carCheckpoint = GetComponent<CarCheckPoint>();
        playerTransform = GameObject.Find("Player").transform; //Set the player transform
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(carCheckpoint.currentCheckpoint);
        //Is it the Player who enters the collider?
        if (other.gameObject.tag == "Player")
            

        //Is this transform equal to the transform of checkpointArrays[currentCheckpoint]?
        
            //Check so we dont exceed our checkpoint quantity
            if (carCheckpoint.currentCheckpoint + 1 < carCheckpoint.checkPointArray.Length)
            {
                //Add to currentLap if currentCheckpoint is 0
                if (carCheckpoint.currentCheckpoint == 0)
                    carCheckpoint.currentLap++;
                carCheckpoint.currentCheckpoint++;
            }
            else
            {
                //If we dont have any Checkpoints left, go back to 0
                carCheckpoint.currentCheckpoint = 0;
            }
           
                         //Update the 3dtext
            
        }
    
    */
   
}
