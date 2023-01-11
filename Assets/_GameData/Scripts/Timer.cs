using System.Collections;
using _GameData.Scripts.Managers;
using TMPro;
using UnityEngine;

namespace _GameData.Scripts
{
    public class Timer : MonoBehaviour
    {
        private TMP_Text _timerText;
        private float _totalTime;
        private float _timer;

        private void Start()
        {
            _timerText = GetComponent<TMP_Text>();
            _totalTime = LevelDataManager.ınstance.levelData.coutdownTime;
            StartCoroutine(TimerCoroutine(_totalTime));
        }

        IEnumerator TimerCoroutine(float totalTime)
        {
            float alpha = 0;
            float timer = totalTime;
            while (alpha < totalTime)
            {
                alpha += Time.deltaTime;
                timer -= Time.deltaTime;
            
                int minutes = Mathf.FloorToInt(timer / 60f);
                int seconds = Mathf.RoundToInt(timer % 60f);

                if (seconds == 60)
                {
                    seconds = 0;
                    minutes += 1;
                }
 
                _timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
                yield return new WaitForEndOfFrame();
            }
            _timerText.text = "00:00";
            EventManager.RaiseTimesUp();
        }
    
    }
}
