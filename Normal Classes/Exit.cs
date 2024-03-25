using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit 
{
    private string direction;
    private Room destinationRoom;
    //constructs an exit
    public Exit(string direction, Room destinationRoom)
    {
        this.direction = direction;
        this.destinationRoom = destinationRoom;
    }
    //returns the desination room of this exit
    public Room getDestinationRoom()
    {
        return this.destinationRoom;
    }
    //returns this direction
    public string getDirection()
    {
        return this.direction;
    }
}
