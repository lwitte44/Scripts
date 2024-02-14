using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Player1Controller : MonoBehaviour
{
    private Player thePlayer;
    public TextMeshPro tm;
    //public GameObject destinationGO;//GO means game object
    //private float speed = 5.0f;

    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float playerSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();

        this.thePlayer = new Player("Aragorn");
        this.tm.text = this.thePlayer.getName() + " HP: " + this.thePlayer.getHP();
        // this.tm.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z);
        //this.gameObject.transform.position = this.destinationGO.transform.position;

    }
    void OnMove(InputValue movementValue)
    {
        //assigns the movementValue input to the variable movementVector
        //Vector2 is the variable type
        Vector2 movementVector = movementValue.Get<Vector2>();
        //assigns the variables to there respective directions of movement
        movementX = movementVector.x;
        //technically refers to the z movement because y is for vertical
        movementY = movementVector.y;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //this.thePlayer.display();

        /////movement code
        //Vector3 variables deal with 3 directions of movement while Vector2 deals with two
        //0.0f means that the Y value (vertical movement) is a float type variable with a value of 0.0
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        //Rigidbody rb will have force added to it in the directions of the "movement" variable
        rb.AddForce(movement * playerSpeed);
        /////


        /*
        if (this.gameObject.transform.position != this.destinationGO.transform.position)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.destinationGO.transform.position, speed * Time.deltaTime);
        }
        */


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
