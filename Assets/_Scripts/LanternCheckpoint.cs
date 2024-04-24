using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LanternCheckpoint : MonoBehaviour
{
    [SerializeField] private GameObject lightObj;
    [SerializeField] private TextMeshPro textIndicator;

    [SerializeField] private int matchesNeededToActivate;
    private int currentAmountOfMatches;

    private int amountLeftToActivate => matchesNeededToActivate - currentAmountOfMatches;
    public bool activated { get; private set; }


    private void Start()
    {
        lightObj.SetActive(false);
        textIndicator.text = matchesNeededToActivate.ToString();
    }

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
        // GetComponent<SpriteRenderer>().color = Color.yellow;
        lightObj.SetActive(true);
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
