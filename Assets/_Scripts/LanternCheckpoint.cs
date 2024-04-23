using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternCheckpoint : MonoBehaviour
{
    [SerializeField] private int matchesNeededToActivate;
    private int currentAmountOfMatches;

    private int amountLeftToActivate => matchesNeededToActivate - currentAmountOfMatches;
    public bool activated { get; private set; }


    /// <summary>
    /// Add Matches to the Lantern
    /// </summary>
    /// <param name="amountToAdd">AmountOfMatchesToAdd</param>
    /// <returns>Amount of matches added</returns>
    public int AddMatches(int amountToAdd)
    {
        print("Trying to add " + amountToAdd + " Matches to lantern, matches needed to activate: " + amountLeftToActivate);

        int matchesAdded = amountToAdd;

        if (amountToAdd >= amountLeftToActivate)
        {
            matchesAdded = amountLeftToActivate;
            print("Added " + matchesAdded + " Matches to lantern");
            Activate();
        }
        else
        {
            currentAmountOfMatches += amountToAdd;
            print("Added " + amountToAdd + " Matches to lantern, matches needed to activate: " + amountLeftToActivate);
        }

        return matchesAdded;
    }

    private void Activate()
    {
        print("Lantern activated");
        GetComponent<SpriteRenderer>().color = Color.yellow;
        currentAmountOfMatches = matchesNeededToActivate;
        activated = true;
    }
}
