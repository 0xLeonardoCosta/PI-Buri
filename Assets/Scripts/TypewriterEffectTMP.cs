using UnityEngine;
using TMPro;
using System.Collections;

public class TypewriterEffectTMP : MonoBehaviour
{
    public TMP_Text tmpText;
    [TextArea]
    public string fullText = "Digite seu texto aqui";
    public float typingSpeed = 0.05f;

    private Coroutine typingCoroutine;

    public void StartTyping()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);  // Para qualquer digitação anterior
        }
        tmpText.text = "";
        typingCoroutine = StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            tmpText.text = fullText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
