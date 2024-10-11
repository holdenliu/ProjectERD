using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStand : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Set the player's parent to this platform
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collider that exited has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Remove the player's parent (detach from platform)
            other.transform.parent = null;
        }
    }
}
