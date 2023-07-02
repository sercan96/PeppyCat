using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject UIScreen;
    public SceneFader sceneFader;
    public static UIManager Instance;
    
    private void OnEnable()
    {
        EventManager.OnGameStart += UICanvasDeActivate;
    }
    private void OnDisable()
    {
        EventManager.OnGameStart -= UICanvasDeActivate;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void UICanvasDeActivate()
    {
        UIScreen.SetActive(false);
    }
    private void UICanvasActivate()
    {
        UIScreen.SetActive(true);
    }
    public void PlayButtonClick()
    {
        GameManager.Instance.OnPlay();
        sceneFader.FadeTo();
    }
}
