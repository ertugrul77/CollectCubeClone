using Unity.Entities;
using Unity.Mathematics;

public struct MouseInput : IComponentData
{
    public float3 position;
    public bool leftButtonDown;
    public bool rightButtonDown;
}
