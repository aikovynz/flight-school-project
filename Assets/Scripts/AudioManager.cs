using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource sfxSource;
    public AudioSource bgmSource;

    [Header("Audio Clips")]
    public AudioClip scoreSound;
    public AudioClip hitSound;
    public AudioClip buttonClickSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayScoreSound()
    {
        PlaySFX(scoreSound);
    }

    public void PlayHitSound()
    {
        PlaySFX(hitSound);
    }

    public void PlayButtonClickSound()
    {
        PlaySFX(buttonClickSound);
    }

    private void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
