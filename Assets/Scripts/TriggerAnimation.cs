using UnityEngine;
using UnityEngine.AI;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    GameObject _gameObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Ensure the colliding object has the tag "Player"
        {
            animator.SetTrigger("StartAnimation"); // Set the trigger
            Debug.Log(other.gameObject.name);
            _gameObject = gameObject;
         //   other.GetComponent<NavMeshAgent>().isStopped = true;
            Invoke("VoltarAndar", 2);
        }
    }

    void VoltarAndar()
    {
        _gameObject.GetComponent<NavMeshAgent>().isStopped = false;
    }
}
