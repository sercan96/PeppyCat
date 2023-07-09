using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject gameUI;
    public GameObject upgradePanelUI;
    public SceneFader sceneFader;
    public static UIManager Instance;

    public int animalCardId;
    
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
        SetUIActive(UIScreen, false);
        SetUIActive(gameUI, true);
        SetUIActive(upgradePanelUI, false);
    }

    private void EnableUI()
    {
        SetUIActive(UIScreen, true);
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
    public void PlayMixedButtonClick()
    {
        GameManager.Instance.OnMixedPlay();
        sceneFader.FadeTo();
    }
    
    public void PlayOneAnimalButtonClick(int id)
    {
        animalCardId = id;
        GameManager.Instance.OnOneAnimalPlay();
        sceneFader.FadeTo();
    }

    public void ClickStuff()
    {
        SetUIActive(upgradePanelUI, true);
        SetUIActive(UIScreen, false);
    }
    
    public void BackHomeButton()
    {
        SetUIActive(UIScreen, true);
        SetUIActive(upgradePanelUI, false);
    }
}
