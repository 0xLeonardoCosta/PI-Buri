
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaladeiraController : MonoBehaviour
{
    public Transform targetPosition;

    void Start()
    {
        // Obtenha o componente ParticleSystem associado ao GameObject
        ParticleSystem particleSystem = GetComponent<ParticleSystem>();

        // Verifique se o alvo (targetPosition) está definido
        if (targetPosition != null)
        {
            // Obtenha o componente MainModule do sistema de partículas
            ParticleSystem.MainModule mainModule = particleSystem.main;

            // Ajuste a posição final das partículas para o alvo
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            // Crie um objeto de sistema de partículas
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];

            // Obtenha as partículas atuais no sistema
            int numParticlesAlive = particleSystem.GetParticles(particles);

            // Atualize as posições iniciais das partículas para que elas atinjam o alvo
            for (int i = 0; i < numParticlesAlive; i++)
            {
                particles[i].position = targetPosition.position;
            }

            // Atualize o sistema com as novas posições
            particleSystem.SetParticles(particles, numParticlesAlive);
        }
        else
        {
            Debug.LogError("Target position not set for ParticleController script.");
        }
    }
}
