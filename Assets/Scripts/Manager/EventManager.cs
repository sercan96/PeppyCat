using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public static class EventManager
    {
        public static event UnityAction<string> OnTargetStop;

        public static void InvokeOnTargetStop(string tag)
        {
            OnTargetStop?.Invoke(tag);
        }
        
        public static event UnityAction<string> OnTargetMove;

        public static void InvokeOnTargetMove(string tag)
        {
            OnTargetMove?.Invoke(tag);
        }
        
        public static event UnityAction<string> OnTargetRun;

        public static void InvokeOnTargetRun(string tag)
        {
            OnTargetRun?.Invoke(tag);
        }
        
        public static event UnityAction OnTargetDie;

        public static void InvokeOnTargetDie()
        {
            OnTargetDie?.Invoke();
        }
        
        public static event UnityAction OnGameStart;

        public static void InvokeOnGameStart()
        {
            OnGameStart?.Invoke();
        }
        
        public static event UnityAction<bool> OnGameModeMixed;
        public static void InvokeOnGameModeMixed()
        {
            OnGameModeMixed?.Invoke(true);
        }
        
        public static event UnityAction<bool> OnGameModeSingular;
        public static void InvokeOnGameModeSingular()
        {
            OnGameModeSingular?.Invoke(false);
        }
    }
}