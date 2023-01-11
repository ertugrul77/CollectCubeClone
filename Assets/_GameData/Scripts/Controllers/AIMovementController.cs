using _GameData.Scripts.Managers;
using UnityEngine;
using Random = UnityEngine.Random;
public class AIMovementController : MonoBehaviour
{
    [SerializeField] private Transform baseTransform;

    private Quaternion _newRotation;
    private Rigidbody _rb;
    private Vector3 _destination;
    private Vector3 _direction;
    private Vector3 _moveDirection;
    private float _movementSpeed;
    private float _distance;
    private bool _isGameEnd;
    
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
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _movementSpeed = LevelDataManager.ınstance.levelData.AIMoveSpeed;
        SetRandomPosition();
    }

    private void Update()
    {
        if (_isGameEnd) enabled = false;
        
        _rb.velocity = Vector3.zero;
        _distance = Vector3.Distance(transform.position, _destination);
        
        if (_distance <= 4f)
        {   
            var randomNumber = Random.Range(0, 5);
            if (randomNumber == 3)
            {
                GoToBase();
            }
            else
            {
                SetRandomPosition();
            }
        }
    }
    private void FixedUpdate()
    {
        MoveToDestination();
    }
    private void MoveToDestination()
    {
        const float directionSmooting = 1f;
        _moveDirection.x = Mathf.Lerp(_moveDirection.x, _direction.x, directionSmooting) ;
        _moveDirection.z = Mathf.Lerp(_moveDirection.z, _direction.z, directionSmooting) ;
        _moveDirection.y = 0f;
        
        _newRotation = Quaternion.LookRotation(_moveDirection);
        Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f) * Time.deltaTime);
        _rb.MoveRotation(_newRotation * deltaRotation);
        
        _rb.velocity = _direction * _movementSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out FrameWall frameWall))
            GoToBase();
    }

    private void SetRandomPosition()
    {
        var cubes = LevelDataManager.ınstance.cubes;
        int index = Random.Range(0, cubes.Count - 1);
        _destination = cubes[index].transform.position;
        _direction = (_destination - transform.position).normalized;
        _destination = cubes[index].transform.position - _direction;
    }
    private void GoToBase()
    {
        _destination = baseTransform.position;
        _direction = (_destination - transform.position).normalized;
    }
    private void OnGameFinishedHandler() { _isGameEnd = true; }
    private void OnTimesUpHandler() { _isGameEnd = true; }
}
