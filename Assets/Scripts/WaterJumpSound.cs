using UnityEngine;

public class WaterJumpSound : MonoBehaviour
{
    public AudioSource waterJumpAudioSource;  // Componente de �udio com o som de pulo na �gua
    public Animator characterAnimator;          // Animator do personagem
    public string waterParameter = "EstaNaAgua"; // Nome do par�metro booleano
    private bool hasJumpedInWater = false;     // Controle para garantir que o som seja tocado apenas uma vez

    void Update()
    {
        // Verifica se o personagem est� na �gua
        bool isInWater = characterAnimator.GetBool(waterParameter);

        if (isInWater && !hasJumpedInWater)
        {
            // Se est� na �gua e ainda n�o tocou o som
            waterJumpAudioSource.Play(); // Toca o �udio
            hasJumpedInWater = true; // Marca que o som j� foi tocado
        }
        else if (!isInWater)
        {
            // Se saiu da �gua, reseta a condi��o
            hasJumpedInWater = false; // Permite que o som seja tocado novamente quando entrar na �gua
        }
    }
}
