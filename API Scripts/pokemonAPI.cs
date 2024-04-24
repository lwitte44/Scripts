using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;  // Required for UnityWebRequest
using UnityEngine.UI;         // Required for UI elements like Text

public class pokemonAPI : MonoBehaviour
{   
    
    void Start()
    {
        StartCoroutine(GetRequest("https://pokeapi.co/api/v2/pokemon/?offset=0&limit=2000"));

        
        
    }

    IEnumerator GetRequest(string url)
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
}