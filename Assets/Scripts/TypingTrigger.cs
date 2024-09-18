using UnityEngine;

public class TypingTrigger : MonoBehaviour
{
    public TypewriterEffectTMP typewriterEffect;

    public void TriggerTyping()
    {
        if (typewriterEffect != null)
        {
            typewriterEffect.StartTyping();  // Assumindo que StartTyping é um método público para iniciar a digitação
        }
    }
}
