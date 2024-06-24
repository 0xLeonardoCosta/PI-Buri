using UnityEngine;
using UnityEngine.AI;

public class MoveToTrigger : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destination;  //tempo da primeira cam1
    public Transform destination2; //animação de fala
    public bool _iniciar;
    bool _outrodest;
    public float parada;
    AgentMovement agentMovement;

    void Update()
    {
        if (_iniciar) // Supondo que o movimento é iniciado com um clique do mouse
        {
            agent.SetDestination(destination.position);
            if (agent.remainingDistance < 1 && !_outrodest)
            {
                _outrodest = true;
                agentMovement._startRot = true;
                Invoke("OutroDestido", parada);
            }
        }
        else
        {
            agent.isStopped = true;
        }

      
    }

    private void Start()
    {
        agentMovement = GetComponent<AgentMovement>();
    }
    void OutroDestido()
    {
        destination = destination2;
        agentMovement._startRot = false;
    }
}
