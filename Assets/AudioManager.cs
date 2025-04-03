using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip death;
    public AudioClip bell;
    public AudioClip candle;
    public AudioClip footstep;
    public AudioClip mirror;
    public AudioClip movePlatform;
    public AudioClip obstacleDissapear;
    public AudioClip platform;
    public AudioClip crusher;
    public AudioClip background2;

    private void Start() 
    {
        if (musicSource != null && background != null)
        {
            musicSource.clip = background; 
            musicSource.loop = true;       
            musicSource.Play();            
        }
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}

   
