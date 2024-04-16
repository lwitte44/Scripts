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
    public GameObject Upgrade;
    public TextMeshPro UpgradeDescription;
    public TextMeshProUGUI RubyErrorMessage;
    public TextMeshProUGUI RubyCount;
    private int upgradePrice = 3;
    // Start is called before the first frame update
    void Start()
    {
        setCount();

        ////////////////

        this.updatePlayerTMP();
        this.itemTMP.text = "" + ItemsSingleton.steakItemCost;

        //read plain text file
        this.readItemsData();

        //read json file with serialization
        string jsonString = this.readItemsDataJson();

        // Parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);

        // Output the data to the console
        foreach (var item in root.items)
        {
            print($"Name: {item.name}, Stat Impacted: {item.stat_impacted}, Modifier: {item.modifier}");
        }

        /////////////////

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.G))
        {
            if (MySingleton.count >= upgradePrice)
            {
                this.Upgrade.gameObject.SetActive(false);
                this.UpgradeDescription.gameObject.SetActive(false);
                MySingleton.hasUpgrade = true;
                MySingleton.count = MySingleton.count - upgradePrice;
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

 
  /////////////////////////
  

    private void readItemsData()
    {
        string filePath = "Assets/Data Files/items_data.txt"; // Path to the file
        string answer = "";

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
                        Item theItem = new Item(itemParts[0], itemParts[1], int.Parse(itemParts[2]));
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

    ///////////////////
    
}
