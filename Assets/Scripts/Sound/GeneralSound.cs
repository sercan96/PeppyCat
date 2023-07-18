using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Managers;

public class GeneralSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void OnEnable() {
        EventManager.OnGameStart +=Stop;
    }

     private void OnDisable() {
        EventManager.OnGameStart -=Stop;
    }

    private void Start() {
        PlayGeneralSound();
    }
    private void PlayGeneralSound() {
        audioSource.Play();
    }

    private void Stop() {
        audioSource.Stop();
    }

}
