using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class SingularSound : Sound
{
    public AudioClip moveSound;

    protected override void OnEnable()
    {
        base.OnEnable();
        audioSource.clip = moveSound;
    }

    private void OnDisable()
    {
        audioSource.clip = moveSound;
    }

    public override void PlayAnimalSound()
    {
        if (audioSource == null || moveSound == null)
            return;
        
        if (isMoveSound)
            return;
        
        isPlayingEscapeSound = false;
        isMoveSound = true;
        audioSource.clip = moveSound;
        audioSource.Play();

    }

    public void StopSound()
    {
        audioSource.Stop();
        isMoveSound = false;
    }
}
