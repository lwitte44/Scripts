using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArmorCollectible : Collectible //the ":" means extends
{
   public ArmorCollectible() : base(1) //base is C#'s evuivelent of Java's super; this calls the parent class "Collectible"
    {
        //we already have our instance of Collectible^^
        //differeniate our armor collectible from a normal collectible
        base.bonus = base.bonus * 2;
        base.name = base.name + ": ArmorCollectible";
    }
}
