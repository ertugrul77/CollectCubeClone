using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class RotationAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float DegreesPerSecond = 360.0f;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new RotationSpeed
        {
            RadiansPerSeconds = math.radians(DegreesPerSecond)
        };

        dstManager.AddComponentData(entity, data);
    }
}
