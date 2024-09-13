using UnityEngine;
using UnityEngine.AI; // Para acessar o NavMeshAgent

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource;  // Componente de áudio que tocará os passos
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
        // Verifica se o NavMeshAgent está se movendo
        if (agent.velocity.magnitude > 0.1f && agent.remainingDistance > agent.stoppingDistance)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                // Verifica se o som não está tocando para não sobrepor os sons
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(footstepClip);
                }
                stepTimer = stepInterval; // Reseta o timer
            }
        }
        else
        {
            // Para o som quando o personagem está parado
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            stepTimer = stepInterval; // Reseta o timer quando o personagem para
        }
    }
}
