using UnityEngine;
using UnityEngine.AI; // Para acessar o NavMeshAgent

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource;  // Componente de �udio que tocar� os passos
    public AudioClip footstepClip;   // O som dos passos
    public float stepInterval = 0.5f; // Intervalo entre os sons dos passos
    private float stepTimer;         // Timer para controlar o intervalo
    private NavMeshAgent agent;      // Componente NavMeshAgent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Pega o NavMeshAgent
        stepTimer = stepInterval; // Inicializa o timer
    }

    void Update()
    {
        // Verifica se o NavMeshAgent est� se movendo
        if (agent.velocity.magnitude > 0.1f && agent.remainingDistance > agent.stoppingDistance)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                // Verifica se o som n�o est� tocando para n�o sobrepor os sons
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(footstepClip);
                }
                stepTimer = stepInterval; // Reseta o timer
            }
        }
        else
        {
            // Para o som quando o personagem est� parado
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            stepTimer = stepInterval; // Reseta o timer quando o personagem para
        }
    }
}
