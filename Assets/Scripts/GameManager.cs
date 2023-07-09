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

    public void OnMixedPlay()
    {
        gameState = GameState.PlayMixed;
    }
    public void OnOneAnimalPlay()
    {
        gameState = GameState.PlayJustOneAnimal;
    }
    
    public void OnUI()
    {
        gameState = GameState.UI;
    }
 
        
    

   
}
