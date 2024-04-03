using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inhabitant
{
    protected string name;
    protected Room currentRoom;
    protected int HP;
    protected int AC; //armorClass

    public Inhabitant(string name)
    {
        this.name = name;
        this.currentRoom = null;
        this.HP = Random.Range(10, 16); // between 10 and 15
        this.AC = Random.Range(8, 17); //between 8 and 16
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
    //returns the currentHP of this player
    public int getCurrentHP()
    {
        return this.HP;
    }
    //sets the currentHP of this player
    public void setCurrentHP(int n)
    {
        this.HP = n;
    }
    //returns the currentAC of this player
    public int getCurrentAC()
    {
        return this.AC;
    }
    //sets the currentAC of this player
    public void setCurrentAC(int n)
    {
        this.AC = n;
    }
}
