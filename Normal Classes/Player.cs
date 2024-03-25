using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string name;
    private Room currentRoom;

    //constructs a player
    public Player(string name)
    {
        this.name = name;
        this.currentRoom = null;
    }
    //returns the currentRoom of this player
   public Room getCurrentRoom() 
    {
        return this.currentRoom;
    }
    //sets the currentRoom of this player
    public void setCurrentRoom(Room r) 
    {
        this.currentRoom = r;
    }
}
