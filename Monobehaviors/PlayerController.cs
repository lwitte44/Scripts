using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 0;
    //private bool northPassOpen = false;
    //private bool eastPassOpen = false;
    //private bool southPassOpen = false;
    //private bool westPassOpen = false;
    //public GameObject northBlock;
    //public GameObject southBlock;
    //public GameObject eastBlock;
    //public GameObject westBlock;
    public GameObject northExit, southExit, eastExit, westExit;
    

    public GameObject middleOfTheRoom;
    private Animator playerAnimator;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;
    private string previousExit = "";
    private bool hasPlayerDied = false;

    // UI text component to display count of "PickUp" objects collected.
    public TextMeshProUGUI countText;
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
    // Start is called before the first frame update
    void Start()
    {
        this.playerAnimator = this.gameObject.GetComponent<Animator>();

        this.gameObject.transform.position = middleOfTheRoom.transform.position;
        print("I'm in this room: " + MySingleton.thePlayer.getCurrentRoom());
        //print("****amMoving IS FALSE****");

        SetCountText();

        //disable all exits when the scene first loads
        this.turnOffExits();

        //check direction when the scene loads
        //print(MySingleton.currentDirection);

        //disable the middle collider until we know what our initial state will be
        //it should already be disabled by default, but for clarity, lets do it here
        this.middleOfTheRoom.SetActive(false);
        //print("****MIDDLE IS OFF****");

        if (!MySingleton.currentDirection.Equals("?"))
        {
            //mark ourselves as moving since we are entering the scene through one of the exits
            this.amMoving = true;
            //print("****amMoving IS TRUE****");
            print("****SCENE2 CODE STARTS****");
            //print(MySingleton.currentDirection);

            //we will be positioning the player by one of the exits so we can turn on the middle collider
            this.middleOfTheRoom.SetActive(true);
            //print("****MIDDLE IS ON****");
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

        }
        else
        {
            //We will be positioning the play at the middle
            //so keep the middle collider off for this run of the scene
            this.amMoving = false;
            //print("****amMoving IS FALSE****");
            this.amAtMiddleOfRoom = true;
            this.middleOfTheRoom.SetActive(false);
            //print("****MIDDLE IS OFF****");
            this.gameObject.transform.position = this.middleOfTheRoom.transform.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (amMoving == true)
        {
            playerAnimator.SetBool("isWalking", true);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            EditorSceneManager.LoadScene("ShopkeeperScene");
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("north"))
        {
            this.amMoving = true;
            //print("****amMoving IS TRUE****");
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("south"))
        {
            this.amMoving = true;
            //print("****amMoving IS TRUE****");
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("west"))
        {
            this.amMoving = true;
            //print("****amMoving IS TRUE****");
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("east"))
        {
            this.amMoving = true;
            //print("****amMoving IS TRUE****");
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("door"))
        {
            //print("****DOOR TRIGGERED****");

            MySingleton.thePlayer.getCurrentRoom().removePlayer(MySingleton.currentDirection);

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
        }
        else if (other.gameObject.CompareTag("collectible"))
        {
            EditorSceneManager.LoadScene("MonsterFight");
            print("****FIGHT SCENE LOADED****");

            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

            // Increment the count of "PickUp" objects collected.
            //MySingleton.count = MySingleton.count + 1;


            Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
            theCurrentRoom.removeCollectible(other.GetComponent<CollectibleController>().direction);

            // Update the count display.
            SetCountText();
        }
        else
        {
            print("****UNTAGGED GAMEOBJECT DETECTED****");
        }
    }
    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText()
    {
        // Update the count text with the current count.
        this.countText.text = "Rubies: " + MySingleton.count.ToString();
    }
}
