using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private string name;
    private int hp;

    public Player(string name)
    {
        //(int) takes the float value, cuts of the decimal numbers, and turns it into an int
        this.hp = (int)Random.Range(10.0f, 20.0f);
        this.name = name;
    }

    public void display()
    {
        Debug.Log(this.name + " -> HP: " + this.hp);
    }

    public string getName()
    {
        return this.name;
    }

    public int getHP()
    {
        return this.hp;
    }
}
