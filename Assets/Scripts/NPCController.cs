using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    public Transform[] pivotPoints; // Os pontos de piv� que o NPC vai intercalar
    public int currentTarget = 0; // O �ndice do pr�ximo ponto de piv�
    private NavMeshAgent agent; // Refer�ncia ao componente NavMeshAgent
    public float pauseDuration = 30f; // Dura��o da pausa em cada ponto de piv�
    public float VelocidadeAndar = 1.0f; // Velocidade de caminhada do NPC
    private Animator animator; // Refer�ncia ao componente Animator
    bool CheckStop;

    void Start()
    {
        agent = GetComponent
        <NavMeshAgent>(); // Obt�m o componente NavMeshAgent do NPC
        animator = GetComponent<Animator>(); // Obt�m o componente Animator do NPC
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
                StartCoroutine(DoPause(pauseDuration)); // Inicia a pausa ap�s alcan�ar o destino
               // agent.isStopped = true;
            }
            
        }
        else
        {
          //  agent.isStopped = false;
            //agent.SetDestination(pivotPoints[currentTarget].position);
        }

        // Atualiza o par�metro de velocidade do Animator com a velocidade do NavMeshAgent
        animator.SetFloat("Speed", Mathf.Abs(agent.velocity.magnitude / agent.speed));
    }

    void SetNextDestination()
    {
        // Define o pr�ximo destino como o pr�ximo ponto de piv�
       // agent.SetDestination(pivotPoints[currentTarget].position);

        // Incrementa o �ndice do pr�ximo ponto de piv� (com loop para voltar ao in�cio quando chegar ao �ltimo ponto)
        currentTarget = (currentTarget + 1) % pivotPoints.Length;
    }

    IEnumerator DoPause(float duration)
    {
       // agent.isStopped = true;
        // Pausa a execu��o do script por 'duration' segundos
        yield return new WaitForSeconds(duration);

        // Define o pr�ximo destino ap�s a pausa
        SetNextDestination();
        CheckStop = false;
     //  agent.isStopped = false;
    }
}