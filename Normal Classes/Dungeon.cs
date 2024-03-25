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
    //constructs a dungeon
    public Dungeon(string name)
    {
        this.name = name;
        
    }
    //sets the startRoom to this room
    public void setStartRoom(Room startRoom)
    {
       this.startRoom = startRoom;
    }
    //adds a player to the dungeon's start room
    public void addPlayer(Player thePlayer)
    {
        this.thePlayer = thePlayer;
        this.startRoom.addPlayer(thePlayer);
    }
}
