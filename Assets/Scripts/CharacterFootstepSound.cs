using UnityEngine;

public class CharacterFootstepSound : MonoBehaviour
{
    public AudioSource footstepAudioSource;  // Componente de �udio com o som dos passos
    public Animator characterAnimator;        // Animator do personagem
    public string inputXParameter = "inputX"; // Nome do par�metro inputX
    public string inputYParameter = "inputY"; // Nome do par�metro inputY
    public string waterParameter = "EstaNaAgua"; // Nome do par�metro booleano
    public float fadeSpeed = 1.0f;            // Velocidade da suaviza��o (fade-in/fade-out)
    public float maxVolume = 1.0f;            // Volume m�ximo do �udio
    public float stopThreshold = 0.1f;        // Limite para considerar o personagem como parado

    void Start()
    {
        footstepAudioSource.volume = 0f;  // Come�a com o volume zerado
    }

    void Update()
    {
        // Obt�m os valores dos par�metros que controlam a movimenta��o
        float inputX = characterAnimator.GetFloat(inputXParameter);
        float inputY = characterAnimator.GetFloat(inputYParameter);
        bool isMoving = (Mathf.Abs(inputX) > stopThreshold || Mathf.Abs(inputY) > stopThreshold);
        bool isInWater = characterAnimator.GetBool(waterParameter); // Verifica se est� na �gua

        if (isInWater) // Se o personagem est� na �gua
        {
            footstepAudioSource.Stop(); // Para o �udio se estiver na �gua
            footstepAudioSource.volume = 0f; // Garante que o volume seja zero
            return; // Sai do Update para evitar execu��o adicional
        }

        if (isMoving) // Se o personagem est� se movendo
        {
            if (!footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Play(); // Inicia o �udio se n�o estiver tocando
            }
            footstepAudioSource.volume = Mathf.MoveTowards(footstepAudioSource.volume, maxVolume, fadeSpeed * Time.deltaTime);
        }
        else
        {
            // Se n�o est� se movendo, suaviza o volume para 0
            footstepAudioSource.volume = Mathf.MoveTowards(footstepAudioSource.volume, 0f, fadeSpeed * Time.deltaTime);
            if (footstepAudioSource.volume == 0f && footstepAudioSource.isPlaying)
            {
                footstepAudioSource.Stop(); // Para o �udio se o volume chegar a 0
            }
        }
    }
}

