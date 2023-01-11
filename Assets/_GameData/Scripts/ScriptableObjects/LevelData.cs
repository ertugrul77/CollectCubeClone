using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create LevelData", fileName = "LevelData", order = 0)]
public class LevelData : ScriptableObject
{

    [Header("Convert Image to Cubes List")]
    public List<Texture2D> levelImages; // Notice to set image being readable
    public GameObject SpawnCube;
    
    [Header("Coutdown Time for the Timer")]
    public float coutdownTime;
    
    [Header("Spawn Cube for ObjectPooler")]
    public int spawnCubeAmount;
    public List<Pool> pools;

    [Header("Player Settings")] 
    public float moveSpeed;
    
    [Header("AI Settings")] 
    public float AIMoveSpeed;
    
    [Header("Cube Generator Spawn Rate")] 
    public float spawnRate;

    [Header("Hole Trigger Settings")] 
    public float forceSpeed;
    public Color AllyColor;
    public Color AIColor;
    
    
    [Serializable]
    public class Pool
    {
        public string tag;
        public Cube cubePrefab;
    }
}
