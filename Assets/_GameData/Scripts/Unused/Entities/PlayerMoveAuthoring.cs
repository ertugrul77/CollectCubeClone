using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public class PlayerMoveAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public float playerMoveSpeed = 20f;
    
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new MoveSpeed
        {
            moveSpeed = playerMoveSpeed
        };

        dstManager.AddComponentData(entity, data);
    }

    
}
