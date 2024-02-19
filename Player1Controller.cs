using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEditor.SceneManagement;

public class Player1Controller : MonoBehaviour
{
    private Player thePlayer;
    public TextMeshPro tm;
    //public GameObject destinationGO;//GO means game object

    //private Rigidbody rb;
    //private float movementX;
    //private float movementY;
    public float playerSpeed = 0;
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject middleOfTheRoom;
    private float speed = 5.0f;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;

    // Start is called before the first frame update
    void Start()
    {
        this.thePlayer = new Player("Aragorn");
        this.tm.text = this.thePlayer.getName() + " HP: " + this.thePlayer.getHP();

        //rb = GetComponent<Rigidbody>();

        // this.tm.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 1, this.gameObject.transform.position.z);
        //this.gameObject.transform.position = this.destinationGO.transform.position;

        //disable all exits when the scene first loads
        this.turnOffExits();

        //not our first scene
        if (!MySingleton.currentDirection.Equals("?"))
        {
            print("Scene2 Code Starts...");
            print(MySingleton.currentDirection);
            if (MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
            }
        }
    }
    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);
    }
    private void turnOnExits()
    {
        this.northExit.gameObject.SetActive(true);
        this.southExit.gameObject.SetActive(true);
        this.eastExit.gameObject.SetActive(true);
        this.westExit.gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            EditorSceneManager.LoadScene("Scene2");
            print("Scene2 Loaded");
        }
        else if (other.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            print("at middle of Room");
            this.amAtMiddleOfRoom = true;
        }
       
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
    // Update is called once per frame
    void Update()
    {
        if (this.amAtMiddleOfRoom == true)
        {
            speed = 0.0f;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);
        }

        //make the player move in the current direction
        if (MySingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.speed * Time.deltaTime);
        }
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
}
