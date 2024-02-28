using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Room
{
    private string name;
    private string[] theOpenDoors = new string[4];
    private int howManyOpenDoors = 0;
    private Exit[] theExits = new Exit[4];
    private int howManyExits = 0;


    public Room (string name)
    {
        this.name = name;
    }

    public void addExit(string direction, Room destinationRoom) 
    {
        if (this.howManyExits < this.theExits.Length)
        {
            Exit e = new Exit(direction, destinationRoom);
            this.theExits[this.howManyExits] = e;
            this.howManyExits++;
        }
        else
        {
            Debug.Log("there are too many exits for this room");
        }
        
    }

    public void setOpenDoor(string direction)
    {
        this.theOpenDoors[this.howManyOpenDoors] = direction;
        this.howManyOpenDoors++;
    }

    public bool isOpenDoor(string direction)
    {
        for(int i = 0; i < this.howManyOpenDoors; i++) 
        {
            if (direction.Equals(this.theOpenDoors[i]))
            {
                return true;
            }
           
        } 
        return false; //whatever direction you wanted to go, does NOT have an open door   
    }
}