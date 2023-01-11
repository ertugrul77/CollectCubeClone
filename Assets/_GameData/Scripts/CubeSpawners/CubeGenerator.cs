using System.Collections;
using _GameData.Scripts.Managers;
using UnityEngine;

namespace _GameData.Scripts.CubeSpawners
{
    public class CubeGenerator : MonoBehaviour
    {
        private Coroutine _spawnCubeCoroutine;
        private float _spawnRate;
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
        private void Start()
        {
            _spawnRate = LevelDataManager.ınstance.levelData.spawnRate;
            ResetAndStartCoroutine(SpawnCube());
        }
        private void ResetAndStartCoroutine(IEnumerator coroutine)
        {
            if(_spawnCubeCoroutine != null) StopCoroutine(_spawnCubeCoroutine);
            _spawnCubeCoroutine = StartCoroutine(coroutine); 
        }
        private IEnumerator SpawnCube()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnRate);
                ObjectPooler.ınstance.SpawnFromPool("Cube", transform.forward, transform.position, 100);
            }
        }

        private void OnGameFinishedHandler() { StopCoroutine(SpawnCube()); }
        private void OnTimesUpHandler() { StopCoroutine(SpawnCube()); }

    }
}
