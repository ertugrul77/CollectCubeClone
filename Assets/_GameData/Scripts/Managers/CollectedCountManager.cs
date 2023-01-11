using TMPro;
using UnityEngine;

namespace _GameData.Scripts.Managers
{
    public class CollectedCountManager : MonoBehaviour
    {
        public static CollectedCountManager ınstance;
        public int totalCubeCount;
    
        [Header("Player Settings")]
        [SerializeField] private TMP_Text allyCountText;
    
        [Header("AI Settings")]
        [SerializeField] private TMP_Text aiCountText;

        private int _allyCollectedCubeCount = 0;
        private int _aiCollectedCubeCount = 0;
    
        public int AllyCollectedCubeCount => _allyCollectedCubeCount;
        public int AiCollectedCubeCount => _aiCollectedCubeCount;

        private void Awake()
        {
            ınstance = this;
        }
        public void AllyCountIncrease(int value)
        {
            _allyCollectedCubeCount += value;
            allyCountText.text = _allyCollectedCubeCount.ToString();
            CheckAllCubeCollected();
        }    
        public void AICountIncrease(int value)
        {
            _aiCollectedCubeCount += value;
            aiCountText.text = _aiCollectedCubeCount.ToString();
            CheckAllCubeCollected();
        }
        private void CheckAllCubeCollected()
        {
            if (totalCubeCount == _allyCollectedCubeCount + _aiCollectedCubeCount)
            {
                EventManager.RaiseGameFinish();
            }
        }
    }
}
