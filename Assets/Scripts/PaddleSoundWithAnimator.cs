using UnityEngine;

public class PaddleSoundWithAnimator : MonoBehaviour
{
    public AudioSource paddleAudioSource;  // Componente de áudio com o som de remo
    public Animator characterAnimator;     // Animator do personagem
    public string Remandonobarco = "Remando no Barco";  // Nome da animação de remar no Animator
    public int animationLayer = 0;         // Camada onde a animação de remar está
    public float fadeSpeed = 1.0f;         // Velocidade da suavização (fade-in/fade-out)
    public float maxVolume = 1.0f;         // Volume máximo do áudio

    void Start()
    {
        paddleAudioSource.volume = 0f;  // Começa com o volume zerado
    }

    void Update()
    {
        // Verifica se a animação "Rowing" está ativa no Animator do personagem
        AnimatorStateInfo stateInfo = characterAnimator.GetCurrentAnimatorStateInfo(animationLayer);

        if (stateInfo.IsName(Remandonobarco))
        {
            // Se a animação está tocando, suaviza o volume para o valor máximo
            if (!paddleAudioSource.isPlaying)
            {
                paddleAudioSource.Play();
            }
            paddleAudioSource.volume = Mathf.MoveTowards(paddleAudioSource.volume, maxVolume, fadeSpeed * Time.deltaTime);
        }
        else
        {
            // Se a animação não está tocando, suaviza o volume para 0 e para o áudio
            paddleAudioSource.volume = Mathf.MoveTowards(paddleAudioSource.volume, 0f, fadeSpeed * Time.deltaTime);
            if (paddleAudioSource.volume == 0f && paddleAudioSource.isPlaying)
            {
                paddleAudioSource.Stop();
            }
        }
    }
}
