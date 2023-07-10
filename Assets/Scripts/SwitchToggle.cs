using UnityEngine;
using UnityEngine.UI ;
using DG.Tweening;
namespace Managers
{
    public class SwitchToggle : MonoBehaviour 
    { 
        [SerializeField] RectTransform uiHandleRectTransform ;
        [SerializeField] Color backgroundActiveColor ;
        [SerializeField] Color handleActiveColor ;
        [SerializeField] PlayScreenUI playScreenUI ;

        Image backgroundImage, handleImage ;

        Color backgroundDefaultColor, handleDefaultColor ;

        Toggle toggle ;

        Vector2 handlePosition ;

        void Awake ( ) {
            toggle = GetComponent <Toggle> ( ) ;

            handlePosition = uiHandleRectTransform.anchoredPosition ;

            backgroundImage = uiHandleRectTransform.parent.GetComponent <Image> ( ) ;
            handleImage = uiHandleRectTransform.GetComponent <Image> ( ) ;

            backgroundDefaultColor = backgroundImage.color ;
            handleDefaultColor = handleImage.color ;

            toggle.onValueChanged.AddListener (OnSwitch) ;

            if (toggle.isOn)
                OnSwitch (true) ;
        }

        void OnSwitch (bool on) {
            //uiHandleRectTransform.anchoredPosition = on ? handlePosition * -1 : handlePosition ; // no anim
            uiHandleRectTransform.DOAnchorPos (on ? handlePosition * -1 : handlePosition, .4f).SetEase (Ease.InOutBack) ;

            //backgroundImage.color = on ? backgroundActiveColor : backgroundDefaultColor ; // no anim
            backgroundImage.DOColor (on ? backgroundActiveColor : backgroundDefaultColor, .6f) ;

            //handleImage.color = on ? handleActiveColor : handleDefaultColor ; // no anim
            handleImage.DOColor (on ? handleActiveColor : handleDefaultColor, .4f) ;

            GameMode(!toggle.isOn);

        }

        void OnDestroy ( ) {
            toggle.onValueChanged.RemoveListener (OnSwitch) ;
        }

        private void GameMode(bool state) // Belki iki mod için event yapılabilir.
        {
            foreach (var animalItem in playScreenUI.animalItems)
            {
                animalItem.button.interactable = state;
            }

            if (state)
            {
                GameManager.Instance.OnOneAnimalPlay(); 
            }
            else
            {
                GameManager.Instance.OnMixedPlay();
            }
            playScreenUI.randomStamp.SetActive(!state);
        }
    }
}