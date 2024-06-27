using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeOutImage : MonoBehaviour
{
    public float fadeDuration = 2f; // Duração do fade out em segundos
    private Image image;

    void Start()
    {
        image = GetComponent<Image>();

        if (image == null)
        {
            Debug.LogError("Image component missing from this game object");
        }
        else
        {
            StartCoroutine(FadeOutRoutine());
        }
    }

    private IEnumerator FadeOutRoutine()
    {
        float startAlpha = image.color.a;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tempColor = image.color;
            tempColor.a = Mathf.Lerp(startAlpha, 0, progress);
            image.color = tempColor;

            progress += rate * Time.deltaTime;

            yield return null;
        }

        Color finalColor = image.color;
        finalColor.a = 0;
        image.color = finalColor;
    }
}