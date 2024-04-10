using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FooterText : MonoBehaviour
{
    public Text textComponent;
    public float scrollSpeed = 50f; // Velocidade de deslizamento

    private RectTransform textTransform;
    private float textWidth;
    public float textWidth2;

    void Start()
    {
        textTransform = textComponent.GetComponent<RectTransform>();
        textWidth2 = textTransform.rect.width;
    }

    void Update()
    {
        // Movimenta o texto horizontalmente
        textTransform.anchoredPosition -= new Vector2(scrollSpeed * Time.deltaTime, 0);

        // Se o texto sair completamente da tela, reposiciona-o para começar de novo
        if (textTransform.anchoredPosition.x < -textWidth)
        {
            // Reposiciona o texto para o início
            textTransform.anchoredPosition += new Vector2(textWidth2, 0);
        }
    }
}

