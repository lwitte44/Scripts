using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    public string stat_impacted;
    public int modifier;
    public int cost;

    public Item(string name, string stat_impacted, int modifier, int cost)
    {
        this.name = name;
        this.stat_impacted = stat_impacted;
        this.modifier = modifier;
        this.cost = cost;
    }

    public void display()
    {
        Debug.Log($"Name: {this.name}, Stat Impacted: {this.stat_impacted}, Modifier: {this.modifier}, Cost: {this.cost}");
    }
}
[System.Serializable]
public class RootObject
{
    public Item[] items;
}

