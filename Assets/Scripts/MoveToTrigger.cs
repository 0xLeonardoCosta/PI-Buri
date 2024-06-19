using UnityEngine;
using UnityEngine.AI;

public class MoveToTrigger : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destination;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Supondo que o movimento é iniciado com um clique do mouse
        {
            agent.SetDestination(destination.position);
        }
    }
}
