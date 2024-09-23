using UnityEngine;

public class PaddleSoundWithAnimator : MonoBehaviour
{
    public AudioSource paddleAudioSource;  // Componente de �udio com o som de remo
    public Animator characterAnimator;     // Animator do personagem
    public string Remandonobarco = "Remando no Barco";  // Nome da anima��o de remar no Animator
    public int animationLayer = 0;         // Camada onde a anima��o de remar est�
    public float fadeSpeed = 1.0f;         // Velocidade da suaviza��o (fade-in/fade-out)
    public float maxVolume = 1.0f;         // Volume m�ximo do �udio

    void Start()
    {
        paddleAudioSource.volume = 0f;  // Come�a com o volume zerado
    }

    void Update()
    {
        // Verifica se a anima��o "Rowing" est� ativa no Animator do personagem
        AnimatorStateInfo stateInfo = characterAnimator.GetCurrentAnimatorStateInfo(animationLayer);

        if (stateInfo.IsName(Remandonobarco))
        {
            // Se a anima��o est� tocando, suaviza o volume para o valor m�ximo
            if (!paddleAudioSource.isPlaying)
            {
                paddleAudioSource.Play();
            }
            paddleAudioSource.volume = Mathf.MoveTowards(paddleAudioSource.volume, maxVolume, fadeSpeed * Time.deltaTime);
        }
        else
        {
            // Se a anima��o n�o est� tocando, suaviza o volume para 0 e para o �udio
            paddleAudioSource.volume = Mathf.MoveTowards(paddleAudioSource.volume, 0f, fadeSpeed * Time.deltaTime);
            if (paddleAudioSource.volume == 0f && paddleAudioSource.isPlaying)
            {
                paddleAudioSource.Stop();
            }
        }
    }
}
