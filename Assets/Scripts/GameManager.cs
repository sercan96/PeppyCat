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
        Play,
        UI,
    }

    public GameState gameState;

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void OnPlay()
    {
        gameState = GameState.Play;
    }
    
    public void OnUI()
    {
        gameState = GameState.UI;
    }
 
        
    

   
}
