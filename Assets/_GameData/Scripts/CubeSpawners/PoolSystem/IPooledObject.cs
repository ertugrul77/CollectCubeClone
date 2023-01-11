
using UnityEngine;

namespace _GameData.Scripts.CubeSpawners.PoolSystem
{
    public interface IPooledObject
    {
        void OnObjectSpawn(Vector3 forward, float forceSpeed);
    }
}
