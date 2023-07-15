using UnityEngine;

namespace Managers
{
    public class MultipleSound : Sound
    {
        public AudioClip[] moveSounds;
        private int soundIndex = 0;

        public override void PlayAnimalSound()
        {
            if (moveSounds.Length <= 0)
                return;
            
            isPlayingEscapeSound = false;
            int randomIndex = Random.Range(0, moveSounds.Length);
            AudioClip randomClip = moveSounds[randomIndex];
            audioSource.clip = randomClip;
            audioSource.Play();
        }
        
    }
}