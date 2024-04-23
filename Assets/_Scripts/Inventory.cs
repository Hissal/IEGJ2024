using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    public static int amountOfMatchesHeld { get; private set; }

    public static void AddMatches(int amount)
    {
        amountOfMatchesHeld += amount;
        Debug.Log("Match added to inventory");
    }

    public static void RemoveMatches(int amount)
    {
        amountOfMatchesHeld -= amount;
        Debug.Log(amount + " Matches removed from inventory");
    }
}
