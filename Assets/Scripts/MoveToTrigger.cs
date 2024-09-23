using UnityEngine;
using UnityEngine.AI;

public class MoveToTrigger : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform destination;  //tempo da primeira cam1
    public Transform destination2; //anima��o de fala
    public bool _iniciar;
    bool _outrodest;
    public float parada;
    AgentMovement agentMovement;

    void Update()
    {
        if (_iniciar) // Supondo que o movimento � iniciado com um clique do mouse
        {
          
            if (agent.remainingDistance < 1 && !_outrodest)
            {
                _outrodest = true;
                agentMovement._startRot = true;
                agent.isStopped = true;
              //  _iniciar=false;
                Invoke("OutroDestido", parada);
            }
            else
            {
                agent.SetDestination(destination.position);
            }
        }
        else
        {
            //agent.isStopped = true;
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
        agent.isStopped = false;
       // _iniciar = true;
    }
}
