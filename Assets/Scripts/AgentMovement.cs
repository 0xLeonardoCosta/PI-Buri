using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public LayerMask areaMask;  // Define the area mask the agent should use
    public float moveRadius = 10f;
    public Animator animator;   // Referência ao Animator
    public MoveToTrigger _toTrigger;

    void Start()
    {
        // Inicializar componentes
        if (agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
        }

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Inicia o movimento para uma posição aleatória
        MoveToRandomPosition();
    }

    void MoveToRandomPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection += transform.position;

        NavMeshHit navHit;
        if (NavMesh.SamplePosition(randomDirection, out navHit, moveRadius, NavMesh.AllAreas))
        {
            agent.SetDestination(navHit.position);
        }
    }

    void Update()
    {
        // Se o agente chegou ao destino ou não tem caminho, move para outra posição aleatória
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            MoveToRandomPosition();
        }

        // Atualiza a animação
        Andar();
    }

    public void AndarIni()
    {
        
        Invoke("TimeAndar", 0.2f);
    }

    void Andar()
    {
        float velocidade = agent.velocity.magnitude;
        animator.SetFloat("Andando", Mathf.Abs(velocidade));
    }

    void TimeAndar()
    {
        _toTrigger._iniciar = true;
        agent.isStopped = false;
        animator.SetInteger("JanocaAnim", 0);
    }
}
