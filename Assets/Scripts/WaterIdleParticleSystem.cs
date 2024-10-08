using UnityEngine;

public class WaterIdleParticleSystem : MonoBehaviour
{
    public ParticleSystem waterIdleParticles;    // O sistema de partículas a ser ativado
    public Animator characterAnimator;           // O Animator do personagem
    public string waterParameter = "EstaNaAgua"; // Parâmetro do Animator que indica se está na água
    public string inputXParameter = "inputX";    // Parâmetro que controla movimento no eixo X
    public string inputYParameter = "inputY";    // Parâmetro que controla movimento no eixo Y

    void Update()
    {
        // Verifica se o personagem está na água
        bool isInWater = characterAnimator.GetBool(waterParameter);
        // Verifica se o personagem está parado
        bool isIdle = characterAnimator.GetFloat(inputXParameter) == 0 && characterAnimator.GetFloat(inputYParameter) == 0;

        if (isInWater && isIdle)
        {
            // Ativa o sistema de partículas quando estiver na água e parado
            if (!waterIdleParticles.isPlaying)
            {
                waterIdleParticles.Play();
            }
        }
        else
        {
            // Desativa as partículas quando o personagem está se movendo ou fora da água
            if (waterIdleParticles.isPlaying)
            {
                waterIdleParticles.Stop();
            }
        }
    }
}