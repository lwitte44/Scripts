using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    //public GameObject[] closedDoors;
    public GameObject northDoor, southDoor, eastDoor, westDoor;
    public GameObject northCollect, southCollect, eastCollect, westCollect;

    // Start is called before the first frame update
    void Start()
    {
       Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if(theCurrentRoom.hasExit("north"))
        {
            this.northDoor.SetActive(false);
            this.northCollect.SetActive(true);
        }
        if (theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
            this.southCollect.SetActive(true);
        }
        if (theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
            this.eastCollect.SetActive(true);
        }
        if (theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
            this.westCollect.SetActive(true);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
