using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayMenuUI : MonoBehaviour
{
    public List<AnimalCardItem> animalCardItems;
    public GameObject randomStamp;
    public AnimalCardItem lastSelectedItem;
    
    private UIManager uiManager;

    private void OnEnable()
    {
        EventManager.OnGameModeMixed += LastSelectedItemState;
        EventManager.OnGameModeSingular += LastSelectedItemState;
    }

    private void OnDisable()
    {
        EventManager.OnGameModeMixed -= LastSelectedItemState;
        EventManager.OnGameModeSingular -= LastSelectedItemState;
    }

    void Start()
    {
        uiManager = UIManager.Instance;
    }

    public void ChooseNewAnimalClick(AnimalCardItem currentAnimalCardItem)
    {
        if(lastSelectedItem != null)
            lastSelectedItem.ticImage.gameObject.SetActive(false);
        lastSelectedItem = currentAnimalCardItem;
    }
    
    public void Play()
    {
        uiManager.sceneFader.FadeTo();
    }

    private void LastSelectedItemState(bool state)
    {
        if (lastSelectedItem == null)
            return;
        
        lastSelectedItem.ticImage.gameObject.SetActive(state);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
