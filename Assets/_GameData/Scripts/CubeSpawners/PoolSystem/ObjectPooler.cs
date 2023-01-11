using System.Collections.Generic;
using _GameData.Scripts.CubeSpawners.PoolSystem;
using _GameData.Scripts.Managers;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler ınstance;
    public Dictionary<string, Queue<Cube>> poolDictionary;
    
    private readonly Queue<Cube> _objectPool = new Queue<Cube>();
    private void Awake()
    {
        ınstance = this;
        poolDictionary = new Dictionary<string, Queue<Cube>>();

        var pools = LevelDataManager.ınstance.levelData.pools;
        var spawnCubeAmount = LevelDataManager.ınstance.levelData.spawnCubeAmount;
        CollectedCountManager.ınstance.totalCubeCount = spawnCubeAmount;

        foreach (var pool in pools)
        {
            for (int i = 0; i < spawnCubeAmount; i++)
            {
                Cube obj = Instantiate(pool.cubePrefab);
                obj.gameObject.SetActive(false);
                _objectPool.Enqueue(obj);
                LevelDataManager.ınstance.cubes.Add(obj.gameObject);
            }
            poolDictionary.Add(pool.tag, _objectPool);
        }
    }
    public void SpawnFromPool(string tag, Vector3 forward, Vector3 position,  float forceSpeed)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
#if UNITY_EDITOR
            Debug.Log("Pool with tag" + tag + " doesn't exist"); return;
#endif
        }

        Cube objectToSpawn = null;
        
        if (_objectPool.Count == 0) return;
        objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.forward = forward;
        objectToSpawn.gameObject.SetActive(true);

        var pooledObject = objectToSpawn.GetComponent<IPooledObject>();
        pooledObject?.OnObjectSpawn(forward, forceSpeed);

    }
}
