using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton
{
    public static string currentDirection = "?";
    private static Room[] theRooms = new Room[100];
    private static int numRooms = 0;
    //"Range(int minInclusive, int maxExclusive)" we need the 5 because then it could return 1-4 because its excluding 5
    private static int numExits = Random.Range(1, 5);

    public static void addRoom(Room room)
    {
        //static context (we dont need to add "this." before the array and int)
        //we can however use the class name that they are from "MySingleton."
        MySingleton.theRooms[numRooms] = room;
        MySingleton.numRooms++;
    }
}

