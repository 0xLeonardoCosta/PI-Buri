using UnityEngine;

public class CharacterFootstepSound : MonoBehaviour
{
    public AudioSource footstepAudioSource;  // Componente de áudio com o som dos passos
    public Animator characterAnimator;        // Animator do personagem
    public string inputXParameter = "inputX"; // Nome do parâmetro inputX
    public string inputYParameter = "inputY"; // Nome do parâmetro inputY
    public string waterParameter = "EstaNaAgua"; // Nome do parâmetro booleano
    public float fadeSpeed = 1.0f;            // Velocidade da suavização (fade-in/fade-out)
    public float maxVolume = 1.0f;            // Volume máximo do áudio
    public float stopThreshold = 0.1f;        // Limite para considerar o personagem como parado

    void Start()
    {
        footstepAudioSource.volume = 0f;  // Começa com o volume zerado
    }

    void Update()
    {
        // Obtém os valores dos parâmetros que controlam a movimentação
        float inputX = characterAnimator.GetFloat(inputXParameter);
        float inputY = characterAnimator.GetFloat(inputYParameter);
        bool isMoving = (Mathf.Abs(inputX) > stopThreshold || Mathf.Abs(inputY) > stopThreshold);
        bool isInWater = characterAnimator.GetBool(waterParameter); // Verifica se está na água

        if (isInWater) // Se o personagem está na água
        {
            footstepAudioSource.Stop(); // Para o áudio se estiver na água
            footstepAudioSource.volume = 0f; // Garante que o volume seja zero
            return; // Sai do Update para evitar execução adicional
        }

        if (isMoving) // Se o personagem está se movendo
        {
            if (!footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Play(); // Inicia o áudio se não estiver tocando
            }
            footstepAudioSource.volume = Mathf.MoveTowards(footstepAudioSource.volume, maxVolume, fadeSpeed * Time.deltaTime);
        }
        else
        {
            // Se não está se movendo, suaviza o volume para 0
            footstepAudioSource.volume = Mathf.MoveTowards(footstepAudioSource.volume, 0f, fadeSpeed * Time.deltaTime);
            if (footstepAudioSource.volume == 0f && footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop(); // Para o áudio se o volume chegar a 0
            }
        }
    }
}

