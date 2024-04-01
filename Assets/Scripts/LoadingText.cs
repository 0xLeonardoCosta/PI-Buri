using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingText : MonoBehaviour
{
    public float letterAppearDelay = 0.5f; // Delay entre a aparição de cada letra
    public string fullText = "Carregando..."; // Texto completo
    private Text textComponent;
    private string currentText = "";

    private void Start()
    {
        textComponent = GetComponent<Text>();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        while (true)
        {
            for (int i = 0; i <= fullText.Length; i++)
            {
                currentText = fullText.Substring(0, i);
                textComponent.text = currentText;
                yield return new WaitForSeconds(letterAppearDelay);
            }
            yield return new WaitForSeconds(letterAppearDelay); // Espera um pouco antes de recomeçar
        }
    }
}