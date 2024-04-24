using UnityEngine;

[System.Serializable]
public class Pokemon
{
    public string name;
    public string url;

    public Pokemon(string name, string url)
    {
        this.name = name;
        this.url = url;
    }

    public void display()
    {
        Debug.Log($"Name: {this.name}, URL: {this.url}");
    }
}

[System.Serializable]
public class CollectionOfPokemon
{
    public int count;
    public string next;
    public string previous;
    public Pokemon[] results;

    public void display()
    {
        //Debug.Log($"Count: {this.count}, Results: {this.results.Length}");//Next: {this.next}, Previous: {this.previous}, 
        for(int i = 0; i < this.results.Length; i++) 
        {
           this.results[i].display();
        }
    }
}