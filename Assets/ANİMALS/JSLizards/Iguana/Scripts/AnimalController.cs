using System;
using Managers;
using Unity.VisualScripting;
using UnityEngine;

namespace JSLizards.Iguana.Scripts
{
    public class AnimalController : MonoBehaviour
    {
        [SerializeField] private AnimatorController animatorCont;
        [SerializeField] private ParticleSystem footPrintParticle;
        public Movement movement;
        
        private void OnEnable()
        {
            EventManager.OnTargetDie += CloseObject;
            EventManager.OnTargetMove += PlayParticle;
            EventManager.OnTargetStop += StopParticle;
        }

        private void OnDisable()
        {
            EventManager.OnTargetMove -= PlayParticle;
            EventManager.OnTargetStop -= StopParticle;
        }

        public void CloseObject()
        {
            EventManager.InvokeOnTargetMove(animatorCont != null ? animatorCont.SetObjectTag() : null);
            Spawner.Instance.lastDeadAnimal = this;
            gameObject.SetActive(false);
        }

        private void PlayParticle(string targetTag)
        {
            if (targetTag == null || targetTag != gameObject.name || footPrintParticle == null) return;
            footPrintParticle.Play();
        }
        private void StopParticle(string targetTag)
        {
            if (targetTag == null || targetTag != gameObject.name ||footPrintParticle == null) return;
            footPrintParticle.Stop();
        }
       
    }

}