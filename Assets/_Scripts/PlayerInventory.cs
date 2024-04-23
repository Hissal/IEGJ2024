using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private bool isTeddy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Match"))
        {
            Inventory.AddMatches(1);
            Destroy(collision.gameObject);
        }
        else if (!isTeddy && collision.gameObject.CompareTag("Lantern"))
        {
            LanternCheckpoint lantern = collision.GetComponent<LanternCheckpoint>();

            if (lantern.activated)
            {
                print("Lantern already active");
                return;
            }
            else if (Inventory.amountOfMatchesHeld == 0)
            {
                print("0 matches in inventory");
                return;
            }

            int matchesAddedToLantern = lantern.AddMatches(Inventory.amountOfMatchesHeld);
            Inventory.RemoveMatches(matchesAddedToLantern);
        }
    }
}
