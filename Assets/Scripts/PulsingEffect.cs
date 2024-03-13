using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingEffect : MonoBehaviour
{
    public float pulseSpeed = 1.0f; // Velocidade da pulsação
    public float maxScale = 1.5f; // Escala máxima durante a pulsação

    private Vector3 baseScale; // Escala original do objeto

    void Start()
    {
        baseScale = transform.localScale; // Salva a escala original do objeto
    }

    void Update()
    {
        // Calcula a escala da pulsação usando uma função senoidal (sin)
        float pulseScale = Mathf.Sin(Time.time * pulseSpeed) * 0.5f + 0.5f;

        // Aplica a escala da pulsação ao objeto
        transform.localScale = baseScale * (1 + pulseScale * maxScale);
    }
}
