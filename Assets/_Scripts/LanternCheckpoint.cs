using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanternCheckpoint : MonoBehaviour
{
    [SerializeField] private TextMeshPro textIndicator;

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

        UpdateText();

        return matchesAdded;
    }

    private void Activate()
    {
        print("Lantern activated");
        GetComponent<SpriteRenderer>().color = Color.yellow;
        currentAmountOfMatches = matchesNeededToActivate;
        activated = true;
    }

    private void UpdateText()
    {
        if (amountLeftToActivate == 0)
        {
            textIndicator.gameObject.SetActive(false);
        }
        else
        {
            textIndicator.text = amountLeftToActivate.ToString();
        } 
    }
}
