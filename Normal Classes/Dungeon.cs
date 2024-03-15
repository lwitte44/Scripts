using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dungeon
{
    private string name;
    private Room startRoom;
    private Room currentRoom;
    private Player thePlayer;
    public Dungeon(string name)
    {
        this.name = name;
        
    }
    public void setStartRoom(Room startRoom)
    {
       this.startRoom = startRoom;
    }
    public void addPlayer(Player thePlayer)
    {
        this.thePlayer = thePlayer;
        this.startRoom.addPlayer(thePlayer);
    }
}
