using _GameData.Scripts.Managers;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    [SerializeField] private bool isAI;

    private SphereCollider _sphereCollider;
    private MeshRenderer _meshRenderer;
    private Vector3 _holePos;
    private Color _collectedColor;
    private float _forceSpeed;
    private float _colliderRadiusOffset = 20;
    private float _collectedCubeCount;
    private int _collectedCubeLayerIndex;
    private int _cubeLayerIndex;
    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _forceSpeed = LevelDataManager.ınstance.levelData.forceSpeed;
        _collectedCubeLayerIndex = LayerMask.NameToLayer("CollectedCube");
        _cubeLayerIndex = LayerMask.NameToLayer("Cube");
        if (isAI)
        {
            _meshRenderer.material.color = LevelDataManager.ınstance.levelData.AIColor;
            _collectedColor = _meshRenderer.material.color;
        }
        else
        {
            _meshRenderer.material.color = LevelDataManager.ınstance.levelData.AllyColor;
            _collectedColor = _meshRenderer.material.color;
        }
        _holePos = GetComponentInParent<Transform>().position;
        _sphereCollider = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != _cubeLayerIndex) return;

        LevelDataManager.ınstance.cubes.Remove(other.gameObject);
        var cube = other.GetComponent<Cube>();

        cube.gameObject.layer = _collectedCubeLayerIndex;
        
        var direction = _holePos - cube.transform.position;
        cube.Rb.AddForce(direction * _forceSpeed);
        cube.cubeMeshRenderer.material.color = _collectedColor;
            
        if (isAI)
        {
            CollectedCountManager.ınstance.AICountIncrease(1);
        }
        else 
        { 
            CollectedCountManager.ınstance.AllyCountIncrease(1);
        }
        _collectedCubeCount++;

        if (!(_collectedCubeCount >= _colliderRadiusOffset)) return;
        _colliderRadiusOffset *= 2;
        _sphereCollider.radius += .5f;
    }

}
