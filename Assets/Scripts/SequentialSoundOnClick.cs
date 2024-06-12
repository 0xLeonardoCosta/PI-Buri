using UnityEngine;
using UnityEngine.UI;

public class SequentialSoundOnClick : MonoBehaviour
{
    public AudioSource firstAudioSource;
    public AudioSource secondAudioSource;

    void Start()
    {
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(PlayFirstSound);
        }
    }

    void PlayFirstSound()
    {
        if (firstAudioSource != null)
        {
            firstAudioSource.Play();
            Invoke("PlaySecondSound", firstAudioSource.clip.length);
        }
    }

    void PlaySecondSound()
    {
        if (secondAudioSource != null)
        {
            secondAudioSource.Play();
        }
    }
}
