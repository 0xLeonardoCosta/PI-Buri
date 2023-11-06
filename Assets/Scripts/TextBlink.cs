using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBlink : MonoBehaviour
{
    public TextMeshProUGUI textMesh; // Arraste o componente TextMeshProUGUI para esse campo no Inspector
    private bool isFadingOut = false;
    [SerializeField] private float blinkSpeed = 1.0f; // Velocidade do piscar (1 segundo no total)

    private void Start()
    {
        StartCoroutine(BlinkText());
    }

    private IEnumerator BlinkText()
    {
        while (true)
        {
            if (isFadingOut)
            {
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 1.0f);
                isFadingOut = false;
            }
            else
            {
                textMesh.color = new Color(textMesh.color.r, textMesh.color.g, textMesh.color.b, 0.0f);
                isFadingOut = true;
            }

            yield return new WaitForSeconds(blinkSpeed / 2);
        }
    }
}
