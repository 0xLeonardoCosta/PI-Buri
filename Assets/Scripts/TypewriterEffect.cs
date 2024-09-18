using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public Text uiText;  // Componente de UI Text
    [TextArea]  // Isso permite que você edite o texto completo no Inspector com mais espaço
    public string fullText;  // Texto completo que será digitado
    public float typingSpeed = 0.05f;  // Velocidade da digitação (ajustável no Inspector)

    private string currentText = "";  // Texto que vai sendo exibido gradualmente

    void Start()
    {
        uiText.text = "";  // Começa com o texto vazio na tela
        StartCoroutine(ShowText());  // Inicia o efeito de digitação
    }

    IEnumerator ShowText()
    {
        // Percorre cada caractere do texto completo
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);  // Captura a parte do texto que já foi "digitada"
            uiText.text = currentText;  // Atualiza o texto visível na UI
            yield return new WaitForSeconds(typingSpeed);  // Aguarda antes de mostrar o próximo caractere
        }
    }
}
