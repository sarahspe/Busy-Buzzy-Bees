using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2End : MonoBehaviour
{
    // This method is called when another collider enters the trigger collider attached to the object this script is attached to
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is in the "Player" layer
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // Load the next level
            SceneManager.LoadScene("Surprise");
        }
    }
}
