using UnityEngine;

public class TypingTrigger : MonoBehaviour
{
    public TypewriterEffectTMP typewriterEffect;

    public void TriggerTyping()
    {
        if (typewriterEffect != null)
        {
            typewriterEffect.StartTyping();  // Assumindo que StartTyping � um m�todo p�blico para iniciar a digita��o
        }
    }
}
