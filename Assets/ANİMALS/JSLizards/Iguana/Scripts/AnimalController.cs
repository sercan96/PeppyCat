using Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace JSLizards.Iguana.Scripts
{
    public class AnimalController : MonoBehaviour
    {
        
        public void CloseObject()
        {
            EventManager.InvokeOnTargetMove();
            gameObject.SetActive(false);
        }
    }
}