using Managers;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public GameObject menuUI;
    public GameObject playScreenUI;
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
        SetUIActive(menuUI, false);
        SetUIActive(playScreenUI, true);
    }

    private void EnableUI()
    {
        SetUIActive(menuUI, true);
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
        sceneFader.FadeTo();
    }
    
    public void PlayOneAnimalButtonClick(int id)
    {
        animalCardId = id;
        sceneFader.FadeTo();
    }

    public void ClickStuff()
    {
        SetUIActive(playScreenUI, true);
        SetUIActive(menuUI, false);
    }
    
    public void BackHomeButton()
    {
        SetUIActive(menuUI, true);
        SetUIActive(playScreenUI, false);
    }


}
