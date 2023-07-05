using System;
using Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace JSLizards.Iguana.Scripts
{
    public class AnimalController : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.OnTargetDie += CloseObject;
        }

        public void CloseObject()
        {
            EventManager.InvokeOnTargetMove();
            gameObject.SetActive(false);
        }
    }
}