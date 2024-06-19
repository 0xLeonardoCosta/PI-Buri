using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the colliding object has the tag "Player"
        {
            animator.SetTrigger("StartAnimation"); // Set the trigger
        }
    }
}
