using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public Text uiText;  // Componente de UI Text
    [TextArea]  // Isso permite que voc� edite o texto completo no Inspector com mais espa�o
    public string fullText;  // Texto completo que ser� digitado
    public float typingSpeed = 0.05f;  // Velocidade da digita��o (ajust�vel no Inspector)

    private string currentText = "";  // Texto que vai sendo exibido gradualmente

    void Start()
    {
        uiText.text = "";  // Come�a com o texto vazio na tela
        StartCoroutine(ShowText());  // Inicia o efeito de digita��o
    }

    IEnumerator ShowText()
    {
        // Percorre cada caractere do texto completo
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);  // Captura a parte do texto que j� foi "digitada"
            uiText.text = currentText;  // Atualiza o texto vis�vel na UI
            yield return new WaitForSeconds(typingSpeed);  // Aguarda antes de mostrar o pr�ximo caractere
        }
    }
}
