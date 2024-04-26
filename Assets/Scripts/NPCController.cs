using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public Transform[] pivotPoints; // Os pontos de pivô que o NPC vai intercalar
    public int currentTarget = 0; // O índice do próximo ponto de pivô
    private NavMeshAgent agent; // Referência ao componente NavMeshAgent
    public float pauseDuration = 30f; // Duração da pausa em cada ponto de pivô
    public float VelocidadeAndar = 1.0f; // Velocidade de caminhada do NPC
    private Animator animator; // Referência ao componente Animator
    bool CheckStop;

    void Start()
    {
        agent = GetComponent
        <NavMeshAgent>(); // Obtém o componente NavMeshAgent do NPC
        animator = GetComponent<Animator>(); // Obtém o componente Animator do NPC
        agent.speed = VelocidadeAndar; // Define a velocidade de caminhada do NPC

        SetNextDestination(); // Define o primeiro destino do NPC
    }

    void Update()
    {
        agent.SetDestination(pivotPoints[currentTarget].position);
        // Verifica se o NPC chegou ao destino atual
        if (agent.remainingDistance < 0.1f)
        {
            if (!CheckStop)
            {
              //  CheckStop = true;
                StartCoroutine(DoPause(pauseDuration)); // Inicia a pausa após alcançar o destino
               // agent.isStopped = true;
            }
            
        }
        else
        {
          //  agent.isStopped = false;
            //agent.SetDestination(pivotPoints[currentTarget].position);
        }

        // Atualiza o parâmetro de velocidade do Animator com a velocidade do NavMeshAgent
        animator.SetFloat("Speed", Mathf.Abs(agent.velocity.magnitude / agent.speed));
    }

    void SetNextDestination()
    {
        // Define o próximo destino como o próximo ponto de pivô
       // agent.SetDestination(pivotPoints[currentTarget].position);

        // Incrementa o índice do próximo ponto de pivô (com loop para voltar ao início quando chegar ao último ponto)
        currentTarget = (currentTarget + 1) % pivotPoints.Length;
    }

    IEnumerator DoPause(float duration)
    {
       // agent.isStopped = true;
        // Pausa a execução do script por 'duration' segundos
        yield return new WaitForSeconds(duration);

        // Define o próximo destino após a pausa
        SetNextDestination();
        CheckStop = false;
     //  agent.isStopped = false;
    }
}