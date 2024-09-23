using UnityEngine;

public class WaterJumpSound : MonoBehaviour
{
    public AudioSource waterJumpAudioSource;  // Componente de áudio com o som de pulo na água
    public Animator characterAnimator;          // Animator do personagem
    public string waterParameter = "EstaNaAgua"; // Nome do parâmetro booleano
    private bool hasJumpedInWater = false;     // Controle para garantir que o som seja tocado apenas uma vez

    void Update()
    {
        // Verifica se o personagem está na água
        bool isInWater = characterAnimator.GetBool(waterParameter);

        if (isInWater && !hasJumpedInWater)
        {
            // Se está na água e ainda não tocou o som
            waterJumpAudioSource.Play(); // Toca o áudio
            hasJumpedInWater = true; // Marca que o som já foi tocado
        }
        else if (!isInWater)
        {
            // Se saiu da água, reseta a condição
            hasJumpedInWater = false; // Permite que o som seja tocado novamente quando entrar na água
        }
    }
}
