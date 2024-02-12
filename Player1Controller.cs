using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player1Controller : MonoBehaviour
{
    private Player thePlayer;
    public TextMeshPro tm;
    public GameObject destinationGO;//GO means game object
    private float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

        this.thePlayer = new Player("Aragorn");
        tm.text = this.thePlayer.getName() + " HP: " + this.thePlayer.getHP();
        // this.tm.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z);
        //this.gameObject.transform.position = this.destinationGO.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //this.thePlayer.display();
        this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.destinationGO.transform.position, speed * Time.deltaTime);

        /*
        if (MySingleton.player1turn == true)
        {
            print("****Player1: " + MySingleton.count + "****");
            MySingleton.count++;
            MySingleton.player1turn = false;
        } 
        */
    }
}
