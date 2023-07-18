using System;
using System.Collections;
using System.Collections.Generic;
using JSLizards.Iguana.Scripts;
using Managers;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
   [SerializeField] private Animator animator;
   private string idleAnim = "Idle";
   private string walkAnim = "Walk";
   private string runAnim = "Run";
   private int runAnimSpeedValue = 4;
   private int walkAnimSpeedValue = 2;

 
  
   private void OnEnable()
   {
      EventManager.OnTargetStop += IdleAnim;
      EventManager.OnTargetMove += WalkAnim;
      EventManager.OnTargetRun += RunAnim;

      SetObjectTag();
   }
   
   private void OnDisable()
   {
      EventManager.OnTargetStop -= IdleAnim;
      EventManager.OnTargetMove -= WalkAnim;
      EventManager.OnTargetRun -= RunAnim;
   }
   
   public String SetObjectTag()
   {
      return gameObject.name;
   }
   

   private void IdleAnim(string targetTag)
   {
      if (targetTag == null || targetTag != SetObjectTag()) return;
      animator.SetTrigger(idleAnim);
   }

   private void WalkAnim(string targetTag)
   {
      if (targetTag == null || targetTag != SetObjectTag()) return;
      animator.SetTrigger(walkAnim);
   }

   private void RunAnim(string targetTag)
   {
      if (targetTag == null || targetTag != SetObjectTag()) return;
      animator.SetTrigger(runAnim);

   }
   
   
}
