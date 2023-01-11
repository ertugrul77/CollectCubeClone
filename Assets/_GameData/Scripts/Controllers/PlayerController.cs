using _GameData.Scripts.Managers;
using UnityEngine;

namespace _GameData.Scripts.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody _rigidBody;
        private Vector3 _moveDirection;
        private float _movementSpeed;
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
            _rigidBody = GetComponent<Rigidbody>();
            _movementSpeed = LevelDataManager.ınstance.levelData.moveSpeed;
        }

        void Update()
        {
            if (_isGameEnd) return;
            _rigidBody.isKinematic = !InputManager.ınstance.isSwiping;
        }
        private void FixedUpdate()
        {
            if (_isGameEnd) return;
            if (InputManager.ınstance.currentSwipeDelta.magnitude > 30)
            {
                const float directionLerp = 0.1f;
                _moveDirection.x = Mathf.Lerp(_moveDirection.x, InputManager.ınstance.direction.x, directionLerp) ;
                _moveDirection.z = Mathf.Lerp(_moveDirection.z, InputManager.ınstance.direction.y, directionLerp) ;
                _moveDirection.y = 0f;
             
                InputManager.ınstance.newRotation = Quaternion.LookRotation(_moveDirection);
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(0f, 360f, 0f) * Time.deltaTime);
                _rigidBody.MoveRotation(InputManager.ınstance.newRotation * deltaRotation);
             
                _rigidBody.velocity = _moveDirection * _movementSpeed;
            }
            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -17f, 17f), transform.position.y, 
                Mathf.Clamp(transform.localPosition.z, -27.5f, 27.5f));
        }

        private void OnGameFinishedHandler()
        {
            _isGameEnd = true;
            InputManager.ınstance.StopMovement();
        }
        private void OnTimesUpHandler()
        {
            _isGameEnd = true;
            InputManager.ınstance.StopMovement();
        }
    }
}
