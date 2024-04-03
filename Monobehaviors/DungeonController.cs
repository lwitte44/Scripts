using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    //public GameObject[] closedDoors;
    public GameObject northDoor, southDoor, eastDoor, westDoor;
    public GameObject northCollectible, southCollectible, eastCollectible, westCollectible;

    // Start is called before the first frame update
    void Start()
    {
       this.setDoors();
       this.setCollectibles();
    }
    //sets up the doors of a new room
    private void setDoors()
    {
        //checks to see if theCurrentRoom has an exit in each given direction

        //gets the current room thePlayer is in from MySingleton
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (theCurrentRoom.hasExit("north"))
        {
            this.northDoor.SetActive(false);
        }
        if (theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
        }
        if (theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
        }
        if (theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
        }
    }
    //sets up the collectibles of a new room
    private void setCollectibles()
    {
        //checks to see if theCurrentRoom has a collectible in each given direction

        //gets the current room thePlayer is in from MySingleton
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (!theCurrentRoom.hasCollectible("north"))
        {
            this.northCollectible.SetActive(false);
        }
        if (!theCurrentRoom.hasCollectible("south"))
        {
            this.southCollectible.SetActive(false);
        }
        if (!theCurrentRoom.hasCollectible("east"))
        {
            this.eastCollectible.SetActive(false);
        }
        if (!theCurrentRoom.hasCollectible("west"))
        {
            this.westCollectible.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
