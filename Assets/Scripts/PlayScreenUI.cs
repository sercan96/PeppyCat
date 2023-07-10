using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayScreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI inputText;

    private UIManager uiManager;

    public List<AnimalCardItem> animalItems;
    public GameObject randomStamp;
    private AnimalCardItem lastSelectedItem;


    void Start()
    {
        uiManager = UIManager.Instance;
    }
    public void IncreaseSpawnAnimalAmount()
    {
        inputText.text = Spawner.Instance.IncreaseValue().ToString();
    }
    
    public void DecreaseSpawnAnimalAmount()
    {
        inputText.text = Spawner.Instance.DecreaseValue().ToString();
    }
    
    public void PlayOneAnimalButtonClick(int id)
    {
        if(lastSelectedItem != null)
            lastSelectedItem.ticImage.gameObject.SetActive(false);
        
        uiManager.animalCardId = id;
        lastSelectedItem = animalItems[id];
        lastSelectedItem.ticImage.gameObject.SetActive(true);
    }

    public void Play()
    {
        uiManager.sceneFader.FadeTo();
    }
}
