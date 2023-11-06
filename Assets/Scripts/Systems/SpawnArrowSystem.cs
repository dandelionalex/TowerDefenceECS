using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[BurstCompile]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public partial struct SpawnArrowSystem : ISystem
{
    [BurstCompile]
    public void OnCreate(ref SystemState state)
    {
        state.RequireForUpdate<YardComponent>();
    }
    
    [BurstCompile]
    public void OnDestroy(ref SystemState state)
    {

    }
    
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        state.Enabled   = false;
        var yardEntity  = SystemAPI.GetSingletonEntity<YardComponent>();
        var yardAspect  = SystemAPI.GetAspect<YardAspect>(yardEntity);
        
        //var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

        for(var i = 0; i<yardAspect.ArrowsAmount; i++)
        {
            //ecb.Instantiate(yardAspect.ArrowPrefab);
            //ecb.SetComponent(yardAspect.ArrowPrefab, LocalTransform.FromPosition( yardAspect.GetRandomPosition() ));
            // or
            Entity arrowEntity = state.EntityManager.Instantiate(yardAspect.ArrowPrefab);
            state.EntityManager.SetComponentData(arrowEntity, LocalTransform.FromPosition( yardAspect.GetRandomPosition() ));
        }       

        //ecb.Playback(state.EntityManager);
    }
}
