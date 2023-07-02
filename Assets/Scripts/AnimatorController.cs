using System;
using System.Collections;
using System.Collections.Generic;
using Managers;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
   [SerializeField] private Animator animator;
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

   private void IdleAnim()
   {
      animator.SetTrigger(idleAnım);
   }

   private void WalkAnim()
   {
      animator.SetTrigger(walkAnim);
   }
   
   private void RunAnim()
   {
      animator.SetTrigger(runAnim);
   }
   
}
