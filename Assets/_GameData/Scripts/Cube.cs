using _GameData.Scripts.CubeSpawners.PoolSystem;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour, IPooledObject
{
    public MeshRenderer cubeMeshRenderer;
    private Rigidbody _rb;
    public Rigidbody Rb => _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
    public void OnObjectSpawn( Vector3 forward, float forceSpeed)
    {
        _rb.AddForce(forward * forceSpeed + RandomDirection());
    }
    private Vector3 RandomDirection()
    {
        float xPos = Random.Range(-20, 20);
        float zPos = Random.Range(-20, 20);
        Vector3 direction = new Vector3(xPos, 0, zPos);

        return direction;
    }
}
    
