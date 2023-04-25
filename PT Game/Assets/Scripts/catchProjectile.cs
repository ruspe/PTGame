using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchProjectile : MonoBehaviour
{
    public Transform respawnPoint; // Assign the respawn point for the fireball
    public GameObject fireball; 

    private bool isTrackingFireball; // Flag to track if a fireball is being tracked

    void Start()
    {
        // Set initial state to not tracking a fireball
        isTrackingFireball = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("projectile") && !isTrackingFireball)
        {
            Destroy(collision.gameObject);
            Debug.Log("Catch!");

            // Call a method to track the fireball with UI indicator
            TrackFireball();

            // Set flag to track fireball
            isTrackingFireball = true;
        }
    }

    private void TrackFireball()
    {
        // Implement logic to track the fireball with UI indicator
        // This can involve showing a UI element, updating UI text, or any other visual indicator as needed

        // Example: Show a UI indicator at a specific position on the screen
        // Vector3 screenPosition = Camera.main.WorldToScreenPoint(respawnPoint.position);
        // Instantiate(/* UI indicator prefab */, screenPosition, Quaternion.identity);

        // Example: Update a UI text element with relevant information
        // UI textElement = /* reference to the UI text element */;
        // textElement.text = "Fireball caught!";
    }

    public void RespawnFireball()
    {
        // Instantiate a new fireball prefab at the respawn point
        GameObject newFireball = Instantiate(fireball, respawnPoint.position, Quaternion.identity);

        // Set the fireball's velocity, direction, or any other properties as needed

        // Reset the flag to stop tracking fireball
        isTrackingFireball = false;
    }
}
