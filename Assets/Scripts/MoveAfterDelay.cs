using UnityEngine;
using UnityEngine.AI;

public class MoveAfterDelay : MonoBehaviour
{
    public Transform destination; // Ponto de destino
    public float delay; // Tempo de espera em segundos antes de se mover

    private NavMeshAgent agent;
    private bool isMoving;
    private float elapsedTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        elapsedTime = 0f;
        isMoving = false;
    }

    void Update()
    {
        if (!isMoving)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= delay)
            {
                isMoving = true;
                agent.SetDestination(destination.position);
            }
        }
    }
}
