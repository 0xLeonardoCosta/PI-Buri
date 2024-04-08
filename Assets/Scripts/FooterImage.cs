using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FooterImage : MonoBehaviour
{
    public Image imageComponent;
    public float scrollSpeed = 50f; // Velocidade de deslizamento

    private RectTransform imageTransform;
    private float imageWidth;

    void Start()
    {
        imageTransform = imageComponent.GetComponent<RectTransform>();
        imageWidth = imageTransform.rect.width;
    }

    void Update()
    {
        // Movimenta a imagem horizontalmente
        imageTransform.anchoredPosition -= new Vector2(scrollSpeed * Time.deltaTime, 0);

        // Se a imagem sair completamente da tela, reposiciona-a para começar de novo
        if (imageTransform.anchoredPosition.x < -2000)
        {
            // Reposiciona a imagem para o início
            imageTransform.anchoredPosition += new Vector2(imageWidth, 0);
        }
    }
}