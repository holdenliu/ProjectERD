using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    // Trigger detection
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Destroy the player GameObject
            Destroy(other.gameObject);
            FindFirstObjectByType<GameManager>().dead();
        }
    }
}
