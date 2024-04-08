using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingPanel : MonoBehaviour
{
    public float rotationSpeed = 50f; // Velocidade de rotação da imagem
    public float floatStrength = 0.5f; // Intensidade da flutuação da imagem
    public float floatSpeed = 1f; // Velocidade da flutuação da imagem

    public float pulseSpeed = 1.0f; // Velocidade da pulsação
    public float maxScale = 1.5f; // Escala máxima durante a pulsação

    public Vector3 baseScale; // Escala original do objeto

    private Vector3 startPos;

    void Start()
    {
       // startPos = transform.position;
    }

    void Update()
    {
        // Rotacionar a imagem
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Flutuar a imagem
        // transform.position = startPos + Vector3.up * Mathf.Sin(Time.time * floatSpeed) * floatStrength;

        // Calcula a escala da pulsação usando uma função senoidal (sin)
        float pulseScale = Mathf.Sin(Time.time * pulseSpeed) * 0.5f + 0.5f;

        // Aplica a escala da pulsação ao objeto
        transform.localScale = baseScale * (1 + pulseScale * maxScale);
    }

    
}

