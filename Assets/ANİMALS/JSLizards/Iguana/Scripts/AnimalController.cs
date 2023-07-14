using System;
using Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace JSLizards.Iguana.Scripts
{
    public class AnimalController : MonoBehaviour
    {
        [SerializeField] private AnimatorController animatorCont;
        public Movement movement;
        private void OnEnable()
        {
            EventManager.OnTargetDie += CloseObject;
        }

        public void CloseObject()
        {
            EventManager.InvokeOnTargetMove(animatorCont != null ? animatorCont.SetObjectTag() : null);
            Spawner.Instance.lastDeadAnimal = this;
            gameObject.SetActive(false);
        }
        
        
    }

}