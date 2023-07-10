using System;
using System.Collections;
using System.Collections.Generic;
using JSLizards.Iguana.Scripts;
using Managers;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
   [SerializeField] private Animator animator;
   //[SerializeField] private  string objectTag;
   public int animalId;
   private string idleAnım = "Idle";
   private string walkAnim = "Walk";
   private string runAnim = "Run";
   private int runAnimSpeedValue = 4;
   private int walkAnimSpeedValue = 2;

 
  
   private void OnEnable()
   {
      EventManager.OnTargetStop += IdleAnim;
      EventManager.OnTargetMove += WalkAnim;
      EventManager.OnTargetRun += RunAnim;

      AssignID();

   }
   
   private void OnDisable()
   {
      EventManager.OnTargetStop -= IdleAnim;
      EventManager.OnTargetMove -= WalkAnim;
      EventManager.OnTargetRun -= RunAnim;
   }
   
   public String SetObjectTag()
   {
      // Debug.Log("objectTag + animalId"+ objectTag + animalId);
      // return objectTag + animalId;
      return gameObject.name;
   }

   private void AssignID()
   {
      animalId++;
      SetObjectTag();
   }

   private void IdleAnim(string tag)
   {
      if (tag != SetObjectTag()) return;
      animator.SetTrigger(idleAnım);
   }

   private void WalkAnim(string tag)
   {
      if (tag != SetObjectTag()) return;
      animator.SetTrigger(walkAnim);
   }

   private void RunAnim(string tag)
   {
      if (tag != SetObjectTag()) return;
      animator.SetTrigger(runAnim);

   }
   
   
}
