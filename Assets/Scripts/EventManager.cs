using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public static class EventManager
    {
        public static event UnityAction OnTargetStop;

        public static void InvokeOnTargetStop()
        {
            OnTargetStop?.Invoke();
        }
        
        public static event UnityAction OnTargetMove;

        public static void InvokeOnTargetMove()
        {
            OnTargetMove?.Invoke();
        }
        
        public static event UnityAction OnTargetRun;

        public static void InvokeOnTargetRun()
        {
            OnTargetRun?.Invoke();
        }
        
        public static event UnityAction<Transform> OnTargetDie;

        public static void InvokeOnTargetDie(Transform transform)
        {
            OnTargetDie?.Invoke(transform);
        }
        
        public static event UnityAction OnGameStart;

        public static void InvokeOnGameStart()
        {
            OnGameStart?.Invoke();
        }
    }
}