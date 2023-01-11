using System;

namespace _GameData.Scripts.Managers
{
    public static class EventManager 
    {
        public static event Action OnGameOver;
        public static void RaiseGameOver() => OnGameOver?.Invoke();
    
    
        public static event Action OnGameSucced;
        public static void RaiseGameSucces() => OnGameSucced?.Invoke();
    
        public static event Action OnGameFinished;
        public static void RaiseGameFinish() => OnGameFinished?.Invoke();
    
    
        public static event Action OnTimesUp;
        public static void RaiseTimesUp() => OnTimesUp?.Invoke();
    }
}
