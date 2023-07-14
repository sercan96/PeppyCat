using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Timeline;

public class GameManager : MonoBehaviour
{
    
    public enum GameState
    {
        PlayMixed,
        PlayJustOneAnimal,
        UI,
    }

    public GameState gameState;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        EventManager.OnGameModeMixed += OnMixedPlay;
        EventManager.OnGameModeSingular += OnOneAnimalPlay;
    }
    
    private void OnDisable()
    {
        EventManager.OnGameModeMixed -= OnMixedPlay;
        EventManager.OnGameModeSingular -= OnOneAnimalPlay;
    }

    private void OnMixedPlay(bool state = true)
    {
        gameState = GameState.PlayMixed;
    }
    private void OnOneAnimalPlay(bool state = false)
    {
        gameState = GameState.PlayJustOneAnimal;
    }
    
    public void OnUI()
    {
        gameState = GameState.UI;
    }
 
        
    

   
}
