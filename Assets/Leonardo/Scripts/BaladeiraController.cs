
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

        // Verifique se o alvo (targetPosition) est� definido
        if (targetPosition != null)
        {
            // Obtenha o componente MainModule do sistema de part�culas
            ParticleSystem.MainModule mainModule = particleSystem.main;

            // Ajuste a posi��o final das part�culas para o alvo
            mainModule.simulationSpace = ParticleSystemSimulationSpace.World;

            // Crie um objeto de sistema de part�culas
            ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];

            // Obtenha as part�culas atuais no sistema
            int numParticlesAlive = particleSystem.GetParticles(particles);

            // Atualize as posi��es iniciais das part�culas para que elas atinjam o alvo
            for (int i = 0; i < numParticlesAlive; i++)
            {
                particles[i].position = targetPosition.position;
            }

            // Atualize o sistema com as novas posi��es
            particleSystem.SetParticles(particles, numParticlesAlive);
        }
        else
        {
            Debug.LogError("Target position not set for ParticleController script.");
        }
    }
}
