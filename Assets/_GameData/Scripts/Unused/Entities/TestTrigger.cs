using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;

public class TestTrigger : ITriggerEventsJobBase
{
    public ComponentDataFromEntity<PhysicsVelocity> physicsVelocity;

    
    public void Execute(TriggerEvent triggerEvent)
    {
        
    }
}

