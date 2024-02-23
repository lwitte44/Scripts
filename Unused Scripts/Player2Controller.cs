using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player2Controller : MonoBehaviour
{

    private Player thePlayer;
    public TextMeshPro tm;
    // Start is called before the first frame update
    void Start()
    {
        this.thePlayer = new Player("Legolas");
        tm.text = this.thePlayer.getName() + " HP: " + this.thePlayer.getHP();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //this.thePlayer.display();

        /*
       if (MySingleton.player1turn == false)
        {
            print("****Player2: " + MySingleton.count + "****");
            MySingleton.count++;
            MySingleton.player1turn = true;

        }
        */

    }
}

