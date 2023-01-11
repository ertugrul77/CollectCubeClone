using UnityEngine;

namespace _GameData.Scripts.Managers
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager ınstance;
    
        [HideInInspector] public bool isSwiping;
        [HideInInspector] public Vector3 direction;
        [HideInInspector] public Vector2 startPos;
        [HideInInspector] public Vector2 currentSwipeDelta;
        [HideInInspector] public Quaternion newRotation;

        private void Awake()
        {
            ınstance = this;
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                isSwiping = true;
                direction = Input.mousePosition - (Vector3)startPos;
                direction = Vector3.Normalize(direction);
            }
            if (Input.GetMouseButtonUp(0))
            {
                StopMovement();
            }
            currentSwipeDelta = Vector2.zero;
 
            if (isSwiping)
            {
                currentSwipeDelta = Input.mousePosition - (Vector3)startPos;
            }
        }
    
        public void StopMovement()
        {
            isSwiping = false;
            direction = Vector2.zero;
            newRotation = Quaternion.Euler(Vector3.zero);
        }
    }
}
