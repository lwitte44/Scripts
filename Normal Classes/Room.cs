using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Room
{
    private string name;

    private Exit[] theExits = new Exit[4];
    private int howManyExits = 0;
    private Player currentPlayer;
    private Collectible northCollectible = null;
    private Collectible southCollectible = null;
    private Collectible eastCollectible = null;
    private Collectible westCollectible = null;

    //constructs a room
    public Room (string name)
    {
        this.name = name;
        this.currentPlayer = null;
    }
    //adds a player and sets the player's current room to this room
    public void addPlayer(Player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this);//this updates the player to their new current room
    }
    //adds a collectible to this room
    public void addCollectible(Collectible c, string direction)
    {
        if(direction.Equals("north"))
        {
            this.northCollectible = c;
        }
        else if (direction.Equals("south"))
        {
            this.southCollectible = c;
        }
        else if (direction.Equals("east"))
        {
            this.eastCollectible = c;
        }
        else if (direction.Equals("west"))
        {
            this.westCollectible = c;
        }
        else
        {
            Debug.Log("****NOT VALID COLLECTIBLE DIRECTION****");
        }
    }
    //removes a collectible from this room
    public void removeCollectible(string direction)
    {
        if (direction.Equals("north"))
        {
            this.northCollectible = null;
        }
        else if (direction.Equals("south"))
        {
            this.southCollectible = null;
        }
        else if (direction.Equals("east"))
        {
            this.eastCollectible = null;
        }
        else if (direction.Equals("west"))
        {
            this.westCollectible = null;
        }
        else
        {
            Debug.Log("****NOT VALID COLLECTIBLE DIRECTION****");
        }
    }
    //returns whether there is a collectible in the given direction
    public bool hasCollectible(string direction)
    {
        if (direction.Equals("north"))
        {
            if (this.northCollectible != null)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        else if (direction.Equals("south"))
        {

            if (this.southCollectible != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (direction.Equals("east"))
        {

            if (this.eastCollectible != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (direction.Equals("west"))
        {

            if (this.westCollectible != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Debug.Log("****NOT VALID COLLECTIBLE DIRECTION TO CHECK****");
            return false;
        }
    }
    //removes a player from this room
    public void removePlayer(string direction) 
    {
        Exit theExit = this.getExitGivenDirection(direction);
        Room destinationRoom = theExit.getDestinationRoom();
        destinationRoom.addPlayer(this.currentPlayer);
        this.currentPlayer = null;//finally remove the player that just left from this room
    }
    private Exit getExitGivenDirection(string direction)
    {
        for (int i = 0; i < this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return this.theExits[i]; //returns the exit in the given direction
            }
        }
        return null; //never found the exit
    }
    //checks to see if the direction has an exit
    public bool hasExit(string direction)
    {
        for(int i = 0; i < this.howManyExits; i++)
        {
            if (this.theExits[i].getDirection().Equals(direction))
            {
                return true;
            }
        }
        return false;
    }
    //adds exits to a room but cant go over 4 and adds collectibles in each direction
    public void addExit(string direction, Room destinationRoom)
    {
        if (this.howManyExits < this.theExits.Length)
        {
            Exit e = new Exit(direction, destinationRoom);
            this.theExits[this.howManyExits] = e;
            this.howManyExits++;

            if(direction.Equals("north"))
            {
                this.northCollectible = new ArmorCollectible();
            }
            else if (direction.Equals("south"))
            {
                this.southCollectible = new ArmorCollectible();
            }
            else if (direction.Equals("east"))
            {
                this.eastCollectible = new ArmorCollectible();
            }
            else if (direction.Equals("west"))
            {
                this.westCollectible = new ArmorCollectible();
            }
            else
            {
                Debug.Log("****INVALID DIRECTION TO CREATE COLLECTIBLE****");
            }

        }
        else
        {
            Debug.Log("there are too many exits for this room");
        }

    }
}