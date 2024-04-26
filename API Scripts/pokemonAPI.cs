using System.Collections;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;  // Required for UnityWebRequest
using UnityEngine.UI;         // Required for UI elements like Text

public class pokemonAPI : MonoBehaviour
{   
    
    void Start()
    {
        //StartCoroutine(GetRequest1("https://pokeapi.co/api/v2/pokemon/?offset=0&limit=2000"));
        StartCoroutine(GetRequest2("https://api.coincap.io/v2/assets"));



    }
    /*
    IEnumerator GetRequest1(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                print("Error: " + webRequest.error);
            }
            else
            {
                // Show results as text
                //print(webRequest.downloadHandler.text);
                // Or retrieve results as binary data
                //byte[] results = webRequest.downloadHandler.data;

                //read json file with serialization
                string jsonString = webRequest.downloadHandler.text;

                // Parse the JSON string
                CollectionOfPokemon theCollectionOfPokemon = JsonUtility.FromJson<CollectionOfPokemon>(jsonString);
                theCollectionOfPokemon.display();            
            }
        }
    }
    */

    IEnumerator GetRequest2(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                print("Error: " + webRequest.error);
            }
            else
            {
                // Show results as text
                //print(webRequest.downloadHandler.text);
                // Or retrieve results as binary data
                //byte[] results = webRequest.downloadHandler.data;

                //read json file with serialization
                string jsonString = webRequest.downloadHandler.text;
                //print(jsonString);
                print(this.generateClassString(jsonString));
                // Parse the JSON string
                //CollectionOfCrypto theCollectionOfCrypto = JsonUtility.FromJson<CollectionOfCrypto>(jsonString);
                //theCollectionOfCrypto.display();

                /*
                // Output the data to the console
                foreach (var Pokemon in this.theCollectionOfPokemon)
                {
                   print($"Name: {item.name}, Stat Impacted: {item.stat_impacted}, Modifier: {item.modifier}");
                }
                */
            }
        }
    }

    public string generateClassString (string jsonString)
    {
        print(jsonString);
        string cleanedString = jsonString.Replace(":", "").Replace(",", "").Replace("{", "").Replace("}", "").Replace("[", "").Replace("]", "");
        //char fix = '"';
        //cleanedString = fix + cleanedString;
        cleanedString = cleanedString.Replace('"', ' ').Replace("  ", ";");
        cleanedString = cleanedString.Trim();
        string[] jsonParts = cleanedString.Split(';');
        string newJsonString = "";
        for (int i = 1; i <= jsonString.Length; i+=2)
        {
            
            bool isFirstTime = true;
            newJsonString = newJsonString + jsonParts[i] + " ";
            if (jsonParts[1] == jsonParts[i] && isFirstTime == false)
            {
                break;
            }
            //print(newJsonString);
            isFirstTime = false;
        }
        newJsonString = newJsonString.Trim();
        string[] jsonParts2 = newJsonString.Split(" ");
        string[] uniqueString = jsonParts2.Distinct().ToArray();      
        
        foreach (string part in uniqueString) 
        {   
            print(part);
        }
        
        //print(cleanedString);
        return cleanedString;
        


        //char[] fluffRemoved = { ':', '"', ','};
        //char one = '"';
        //jsonString = jsonString.Remove(one);
        /*
        for (int i = 0; i < fluffRemoved.Length; i++)
        {
            jsonString = jsonString.Remove(fluffRemoved[i]);
        }
        */
        //char[] fluffRemoved = { ':', '"', ',',};
        //string trimmedJsonString = jsonString.Remove('t');

       
        
        /*
        for (int i = 0; i < jsonString.Length; i++) 
        {
        
        }
        */
    }

}