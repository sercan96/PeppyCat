using System.Collections;
using UnityEngine;

public class Sound : MonoBehaviour
{
    protected AudioSource audioSource;
    public AudioClip escapeSound;
    protected bool isPlayingEscapeSound ; 

    protected bool isMoveSound;
    
    protected virtual void OnEnable()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    
    public virtual void PlayAnimalSound()
    {}
    
    public void PlayEscapeSound()
    {
        if (isPlayingEscapeSound)
            return;

        if (escapeSound == null)
            return;
        
        audioSource.clip = escapeSound;
        audioSource.Play();
        audioSource.loop = true;
        isPlayingEscapeSound = true;
        isMoveSound = false;

    }
    
}
