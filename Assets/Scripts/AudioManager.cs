using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource music;
    [SerializeField] AudioSource SFX;


    [Header("Audio Clip")]
    public AudioClip Attack;
    /*public AudioClip Attack;
    public AudioClip Attack;
    public AudioClip Attack;
    public AudioClip Attack;
    public AudioClip Attack;
    public AudioClip Attack;
    public AudioClip Attack;*/

    private void Start()
    {
        //musicSource.clip = background;
        //musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

}

