using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScriptHistory : MonoBehaviour
{
    //public GameObject destinationGO;//GO means game object
    //private Player thePlayer;
    //public TextMeshPro tm;
    //private Rigidbody rb;
    //private float movementX;
    //private float movementY;
    //private float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        //this.thePlayer = new Player("Aragorn");
        //this.tm.text = this.thePlayer.getName() + " HP: " + this.thePlayer.getHP();

        //rb = GetComponent<Rigidbody>();

        // this.tm.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z);
        //this.gameObject.transform.position = this.destinationGO.transform.position;

        //StartCoroutine(TurnOnMiddle());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    // FixedUpdate is called 60 times per frame
    void FixedUpdate()
    {
        //this.thePlayer.display();
        /*
        /////movement code
        //Vector3 variables deal with 3 directions of movement while Vector2 deals with two
        //0.0f means that the Y value (vertical movement) is a float type variable with a value of 0.0
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        //Rigidbody rb will have force added to it in the directions of the "movement" variable
        rb.AddForce(movement * playerSpeed);
        /////
        ///*/
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
    /*
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
    */
    /*
    IEnumerator TurnOnMiddle()
    {
        print("turned on coroutine");
        yield return new WaitForSeconds(1);
        this.middleOfTheRoom.SetActive(true);
        print("My current direction is set as: " + MySingleton.currentDirection + ". I'm looking for the middle now...");

    }
    */
}
