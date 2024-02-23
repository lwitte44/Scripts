using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEditor.SceneManagement;
using System.Runtime.CompilerServices;

public class Player1Controller : MonoBehaviour
{
    public float playerSpeed = 0;
    public GameObject northExit;
    private bool northPassOpen = false;
    private bool eastPassOpen = false;
    private bool southPassOpen = false;
    private bool westPassOpen = false;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject northBlock;
    public GameObject southBlock;
    public GameObject eastBlock;
    public GameObject westBlock;
    public GameObject middleOfTheRoom;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;
    private string previousExit = "";

    // Start is called before the first frame update
    void Start()
    {
        
        
        print("****amMoving IS FALSE****");
        
        //Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();

        //disable all exits when the scene first loads
        this.turnOffExits();

        //check direction when the scene loads
        print(MySingleton.currentDirection);

        //disable the middle collider until we know what our initial state will be
        //it should already be disabled by default, but for clarity, lets do it here
        this.middleOfTheRoom.SetActive(false);
        print("****MIDDLE IS OFF****");

        if (!MySingleton.currentDirection.Equals("?"))
        {
            //mark ourselves as moving since we are entering the scene through one of the exits
            this.amMoving = true;
            print("****amMoving IS TRUE****");
            print("****SCENE2 CODE STARTS****");
            print(MySingleton.currentDirection);

            //we will be positioning the player by one of the exits so we can turn on the middle collider
            this.middleOfTheRoom.SetActive(true);
            print("****MIDDLE IS ON****");
            this.amAtMiddleOfRoom = false;

            if (MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.gameObject.transform.LookAt(this.northExit.transform.position);
                //rb.MovePosition(this.southExit.transform.position);
                this.previousExit = "north";
            }
            else if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.gameObject.transform.LookAt(this.southExit.transform.position);
                //rb.MovePosition(this.northExit.transform.position);
                this.previousExit = "south";
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.gameObject.transform.LookAt(this.westExit.transform.position);
                //rb.MovePosition(this.eastExit.transform.position);
                this.previousExit = "west";
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.gameObject.transform.LookAt(this.eastExit.transform.position);
                //rb.MovePosition(this.westExit.transform.position);
                this.previousExit = "east";
            }
            StartCoroutine(generateExits());
        }
        else
        {
            //We will be positioning the play at the middle
            //so keep the middle collider off for this run of the scene
            this.amMoving = false;
            print("****amMoving IS FALSE****");
            this.amAtMiddleOfRoom = true;
            this.middleOfTheRoom.SetActive(false);
            print("****MIDDLE IS OFF****");
            this.gameObject.transform.position = this.middleOfTheRoom.transform.position;
        }
    }
    IEnumerator generateExits()
    {
        print("turned on coroutine");
        yield return new WaitForSeconds(1);
        getPreviousExit();
        print("****PREVIOUS EXIT DONE****");
        print("****NorthPassOpen: " + this.northPassOpen + " EastPassOpen: " + this.eastPassOpen + " SouthPassOpen: " + this.southPassOpen + " WestPassOpen: " + this.westPassOpen);
        getOpenExits();
        print("****OPEN EXITS DONE****");
        print("****NorthPassOpen: " + this.northPassOpen + " EastPassOpen: " + this.eastPassOpen + " SouthPassOpen: " + this.southPassOpen + " WestPassOpen: " + this.westPassOpen);
        blockExits();
        print("****EXITS BLOCKED****");
        print("****NorthPassOpen: " + this.northPassOpen + " EastPassOpen: " + this.eastPassOpen + " SouthPassOpen: " + this.southPassOpen + " WestPassOpen: " + this.westPassOpen);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving)
        {
            this.amMoving = true;
            print("****amMoving IS TRUE****");
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving)
        {
            this.amMoving = true;
            print("****amMoving IS TRUE****");
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving)
        {
            this.amMoving = true;
            print("****amMoving IS TRUE****");
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving)
        {
            this.amMoving = true;
            print("****amMoving IS TRUE****");
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);
        }
        //make the player move in the current direction
        if (MySingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.playerSpeed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.playerSpeed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.playerSpeed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.playerSpeed * Time.deltaTime);
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
    private void blockExits()
    {
        this.northBlock.gameObject.SetActive(true);
        this.southBlock.gameObject.SetActive(true);
        this.eastBlock.gameObject.SetActive(true);
        this.westBlock.gameObject.SetActive(true);
        if (this.northPassOpen == true)
        {
            this.northBlock.gameObject.SetActive(false);
        }
        if (this.eastPassOpen == true)
        {
            this.eastBlock.gameObject.SetActive(false);
        }
        if (this.southPassOpen == true)
        {
            this.southBlock.gameObject.SetActive(false);
        }
        if (this.westPassOpen == true)
        {
            this.westBlock.gameObject.SetActive(false);
        }
    }
    private void getPreviousExit()
    {
        if (this.previousExit == "north")
        {
            this.southPassOpen = true;
            print("Previous Exit was North ");
        }
        if (this.previousExit == "east")
        {
            this.westPassOpen = true;
            print("Previous Exit was East");
        }
        if (this.previousExit == "south")
        {
            this.northPassOpen = true;
            print("Previous Exit was South");
        }
        if (this.previousExit == "west")
        {
            this.eastPassOpen = true;
            print("Previous Exit was West");
        }
    }
    private void getOpenExits()
    {
        int i = Random.Range(1, 5);
        print("Number of Open Exits: " + i);
        if ( i == 1)
        {
            return;
        }
        if (i == 2)
        {
            this.eastPassOpen = true;
            reRoll();  
        }
        if (i == 3)
        {
            this.southPassOpen = true;
            reRoll();
            reRoll();
        }
        if (i == 4)
        {
            this.westPassOpen = true;
            this.northPassOpen = true;
            this.southPassOpen = true;
            this.eastPassOpen = true;
        }
    }
    private void reRoll()
    {
        int i = Random.Range(1, 5);
        if (i == 1)
        {
            this.northPassOpen = true;
        }
        if (i == 2)
        {
            this.eastPassOpen = true;
        }
        if (i == 3)
        {
            this.southPassOpen = true;
        }
        if (i == 4)
        {
            this.westPassOpen = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("door"))
        {
            print("****DOOR TRIGGERED****");
            EditorSceneManager.LoadScene("Scene1");
            print("****SCENE2 LOADED****");
        }
        else if (other.gameObject.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            //we have hit the middle of the room, so lets turn off the collider
            //until the next run of the scene to avoid additional collisions
            this.middleOfTheRoom.SetActive(false);
            this.turnOnExits();
            print("****AM AT MIDDLE****");
            this.amAtMiddleOfRoom = true;
            this.amMoving = false;
            MySingleton.currentDirection = "middle";
            print(MySingleton.currentDirection);
        }
        else
        {
            print("****UNTAGGED GAMEOBJECT DETECTED****");
        }

    }
}
