using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject gameUI;
    public SceneFader sceneFader;
    public static UIManager Instance;
    
    private void OnEnable()
    {
        EventManager.OnGameStart += MenuUICanvasDeactivate;
    }
    private void OnDisable()
    {
        EventManager.OnGameStart -= MenuUICanvasDeactivate;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void MenuUICanvasDeactivate()
    {
        SetUIActive(menuUI, false);
        SetUIActive(gameUI, true);
    }

    private void EnableUI()
    {
        SetUIActive(menuUI, true);
        SetUIActive(gameUI, false);
    }

    private void SetUIActive(GameObject uiObject, bool isActive)
    {
        if (uiObject != null)
        {
            uiObject.SetActive(isActive);
        }
        else
        {
            Debug.LogWarning("UI object is null.");
        }
    }
    public void PlayButtonClick()
    {
        GameManager.Instance.OnPlay();
        sceneFader.FadeTo();
    }
}
