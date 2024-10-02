using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;            // Reference to the player's Rigidbody
    private Transform originalParent; // Store the original parent of the player

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Initialize Rigidbody reference
        originalParent = transform.parent; // Store the original parent (usually null)
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is on a platform
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = collision.transform; // Parent the player to the platform
        }
    }

    void OnCollisionExit(Collision collision)
    {
        // When the player leaves the platform, reset the parent to the original one
        if (collision.gameObject.CompareTag("Platform"))
        {
            transform.parent = originalParent; // Reset parent to original (null)
        }
    }
}
