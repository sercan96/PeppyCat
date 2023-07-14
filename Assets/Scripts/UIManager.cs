using Managers;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public PlayMenuUI playMenuUI;
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
        SetUIActive(playMenuUI.gameObject, false);
        SetUIActive(gameUI, true);
    }

    private void EnableUI()
    {
        SetUIActive(playMenuUI.gameObject, true);
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

    public void ClickStuff()
    {
        SetUIActive(gameUI, true);
        SetUIActive(playMenuUI.gameObject, false);
    }
    
    public void BackHomeButton()
    {
        SetUIActive(playMenuUI.gameObject, true);
        SetUIActive(gameUI, false);
    }


}
