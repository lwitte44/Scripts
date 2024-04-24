using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using System.IO;
using System;

public class ShopController : MonoBehaviour
{
    public GameObject Shopkeeper;
    //public GameObject SteakUpgrade, CarrotUpgrade, CakeUpgrade, FishUpgrade;
    public TextMeshPro SteakNumberTMP, CarrotNumberTMP, CakeNumberTMP, FishNumberTMP;
    public TextMeshProUGUI RubyErrorMessage;
    public TextMeshProUGUI RubyCount;
    //public GameObject[] UpgradeArray;
    //public TextMeshPro[] ItemNumbersArrayTMP;
    //private int UpgradeIndex = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        setCount();
        //setShop();

        ////////////////

        //this.updatePlayerTMP();
        //this.itemTMP.text = "" + ItemsSingleton.steakItemCost;

        //read plain text file
        this.readItemsData();

        
        //read json file with serialization
        string jsonString = MySingleton.readJsonString(); 

        // Parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);

        
        // Output the data to the console
        foreach (var item in root.items)
        {
            print($"Name: {item.name}, Stat Impacted: {item.stat_impacted}, Modifier: {item.modifier}");
        }
        
       

    }

    // Update is called once per frame
    void Update()
    { 
/////////////////
        /*
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.UpgradeIndex++;
            if(this.UpgradeIndex > UpgradeArray.Length)
            {
                this.UpgradeIndex--;
                setShop();
            }
            setShop();
            
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow)) 
        {
            this.UpgradeIndex--;
            if (this.UpgradeIndex < 0)
            {
                this.UpgradeIndex++;
                setShop();
            }
            setShop();
        }
        */
   ///////////////////////////////////////////     
        
        if(Input.GetKeyUp(KeyCode.G))
        {
            if (MySingleton.count >= ItemsSingleton.steakItemCost)
            {
                //this.Upgrade.gameObject.SetActive(false);
                //this.UpgradeDescription.gameObject.SetActive(false);
                MySingleton.hasUpgrade = true;
                MySingleton.count = MySingleton.count - ItemsSingleton.steakItemCost;
                setCount();

            }
            else
            {
                StartCoroutine(errorMessage());
            }
        }
        else if(Input.GetKeyUp(KeyCode.H))
        {
            EditorSceneManager.LoadScene("Scene1");
        }
    }
    private void setCount()
    {
        this.RubyCount.text = "Rubies: " + MySingleton.count;
    }
    IEnumerator errorMessage()
    {
        this.RubyErrorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        this.RubyErrorMessage.gameObject.SetActive(false);
    }

/////////////////
    /*
    private void setShop()
    {
        this.UpgradeArray[0].gameObject.SetActive(false);
        this.ItemNumbersArrayTMP[0].text = "1";
        this.UpgradeArray[1].gameObject.SetActive(false);
        this.ItemNumbersArrayTMP[1].text = "2";
        this.UpgradeArray[2].gameObject.SetActive(false);
        this.ItemNumbersArrayTMP[2].text = "3";
        this.UpgradeArray[3].gameObject.SetActive(false);
        this.ItemNumbersArrayTMP[3].text = "4";

        this.UpgradeArray[UpgradeIndex].gameObject.SetActive(true);
        this.ItemNumbersArrayTMP[UpgradeIndex].text = "";
    }
    */
    /////////////////////////


    private void readItemsData()
    {
        string filePath = "Assets/Data Files/Items_data.txt"; // Path to the file
        //string answer = "";

        // Check if the file exists
        if (File.Exists(filePath))
        {
            try
            {
                // Open the file to read from
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    string[] itemParts = new string[3];

                    int pos = 0;
                    // Read and display lines from the file until the end of the file is reached
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(",");
                        for (int i = 0; i < parts.Length; i++)
                        {
                            print(parts[i]);
                            itemParts[pos % 3] = parts[i];
                            pos++;
                        }
                        print("Manually parsed with Item Object");
                        Item theItem = new Item(itemParts[0], itemParts[1], int.Parse(itemParts[2]), int.Parse(itemParts[3]));
                        theItem.display();
                    }
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occurred during reading the file
                print("An error occurred while reading the file:");
                print(ex.Message);
            }
        }
        else
        {
            print("The file does not exist.");
        }
    }

////////////////////
    /*
    private string readItemsDataJson()
    {
        string filePath = "Assets/Data Files/items_data_json.txt"; // Path to the file
        string answer = "";

        // Check if the file exists
        if (File.Exists(filePath))
        {
            try
            {
                print("Serialized JSON Parsing");
                // Open the file to read from
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    // Read and display lines from the file until the end of the file is reached
                    while ((line = reader.ReadLine()) != null)
                    {
                        answer = answer + line;
                    }
                    return answer;
                }
            }
            catch (Exception ex)
            {
                // Display any errors that occurred during reading the file
                print("An error occurred while reading the file:");
                print(ex.Message);
                return null;
            }
        }
        else
        {
            print("The file does not exist.");
            return null;
        }
    }

    
    */
///////////////////
}
