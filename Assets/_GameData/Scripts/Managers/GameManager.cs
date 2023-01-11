using UnityEngine;

namespace _GameData.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private void OnEnable()
        {
            EventManager.OnGameFinished += OnGameFinishedHandler;
            EventManager.OnTimesUp += OnTimesUpHandler;
        }
        private void OnDisable()
        {
            EventManager.OnGameFinished -= OnGameFinishedHandler;
            EventManager.OnTimesUp -= OnTimesUpHandler;
        }

        private void OnTimesUpHandler()
        {
            Debug.Log("You collected " + CollectedCountManager.ınstance.AllyCollectedCubeCount + " cubes");
        }

        private void OnGameFinishedHandler()
        {
            Debug.Log(CollectedCountManager.ınstance.AllyCollectedCubeCount >=
                      CollectedCountManager.ınstance.AiCollectedCubeCount
                ? "You Win"
                : "You Lose");
        }
    }
}
