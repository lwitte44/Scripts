using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible
{
    protected int bonus;//"protected" allows it to only be accessed by children of this class
    protected string name;

    //constructs a collectible
    public Collectible(int bonus)
        {
            this.bonus = bonus;
            this.name = "Collectible";
        }
}
