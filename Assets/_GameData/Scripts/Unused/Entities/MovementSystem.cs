using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Physics.Authoring;
using Unity.Transforms;
using UnityEngine;

public class MovementSystem : ComponentSystem
{
    private Vector3 direction;
    private Quaternion targetRotation;
    private float _speed;
    private float clampedSpeed;
    
    protected override void OnUpdate()
    {
        Entities.ForEach((ref PhysicsVelocity physicsVelocity, ref Translation translation , ref Rotation rotation, ref MoveSpeed moveSpeed) =>
        {
            CalculateSpeed(moveSpeed.moveSpeed);
            direction.y = 0;
            translation.Value = new float3(translation.Value.x, 0, translation.Value.z);
            physicsVelocity.Linear = (float3)direction * _speed * Time.DeltaTime;
            if (_speed != 0)
            {
                targetRotation = Quaternion.LookRotation(direction, Vector3.up);
                targetRotation = new Quaternion(0, targetRotation.y, 0, targetRotation.w);
                rotation.Value = Quaternion.Lerp(rotation.Value , targetRotation, moveSpeed.moveSpeed * Time.DeltaTime);
            }
        });
    }

    private void CalculateSpeed(float speedMultiplier)
    {
        direction = InputManagerOld.Instance.lookForward;
        
        var magnitude = InputManagerOld.Instance.magnitude;
        _speed = magnitude * speedMultiplier ;
    }

}

