using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalCardItem : MonoBehaviour
{
    [SerializeField] private AnimalCardData animalCardData;
    public Button button;
    public GameObject ticImage;
    
    public void ButtonClick()
    {
        UIManager.Instance.playMenuUI.ChooseNewAnimalClick(this);
        EnvironmentManager.Instance.ChangeGroundMat(animalCardData.groundMat);
        Spawner.Instance.CatchClickAnimal(animalCardData.animalPrefab);
        ticImage.SetActive(true);
    }
}
