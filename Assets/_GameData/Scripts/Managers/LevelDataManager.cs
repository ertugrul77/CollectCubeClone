using System.Collections.Generic;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    public static LevelDataManager ınstance;
    public LevelData levelData;
    public List<GameObject> cubes;

    private void Awake()
    {
        ınstance = this;
    }
}
