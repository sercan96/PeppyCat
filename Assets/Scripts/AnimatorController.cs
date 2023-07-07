using System;
using System.Collections;
using System.Collections.Generic;
using JSLizards.Iguana.Scripts;
using Managers;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
   [SerializeField] private Animator animator;
   [SerializeField] private  string objectTag;
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
   }
   
   private void OnDisable()
   {
      EventManager.OnTargetStop -= IdleAnim;
      EventManager.OnTargetMove -= WalkAnim;
      EventManager.OnTargetRun -= RunAnim;
   }
   
   public String SetObjectTag()
   {
      return objectTag;
   }

   private void IdleAnim(string tag)
   {
      if (tag != objectTag) return;
      animator.SetTrigger(idleAnım);
   }

   private void WalkAnim(string tag)
   {
      if (tag != objectTag) return;
      animator.SetTrigger(walkAnim);
   }

   private void RunAnim(string tag)
   {
      if (tag != objectTag) return;
      animator.SetTrigger(runAnim);

   }
   
   
}
