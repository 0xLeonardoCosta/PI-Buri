using UnityEngine;

public class WaterIdleParticleSystem : MonoBehaviour
{
    public ParticleSystem waterIdleParticles;    // O sistema de part�culas a ser ativado
    public Animator characterAnimator;           // O Animator do personagem
    public string waterParameter = "EstaNaAgua"; // Par�metro do Animator que indica se est� na �gua
    public string inputXParameter = "inputX";    // Par�metro que controla movimento no eixo X
    public string inputYParameter = "inputY";    // Par�metro que controla movimento no eixo Y

    void Update()
    {
        // Verifica se o personagem est� na �gua
        bool isInWater = characterAnimator.GetBool(waterParameter);
        // Verifica se o personagem est� parado
        bool isIdle = characterAnimator.GetFloat(inputXParameter) == 0 && characterAnimator.GetFloat(inputYParameter) == 0;

        if (isInWater && isIdle)
        {
            // Ativa o sistema de part�culas quando estiver na �gua e parado
            if (!waterIdleParticles.isPlaying)
            {
                waterIdleParticles.Play();
            }
        }
        else
        {
            // Desativa as part�culas quando o personagem est� se movendo ou fora da �gua
            if (waterIdleParticles.isPlaying)
            {
                waterIdleParticles.Stop();
            }
        }
    }
}