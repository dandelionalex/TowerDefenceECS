using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public readonly partial struct YardAspect : IAspect
{
    public readonly Entity Entity;
    //private readonly RefRO<LocalTransform> _localTransform; maybe make it Aspect
    private readonly RefRO<YardComponent> _yardProperties;
    private readonly RefRW<YardRandomComponent> _yardRandom;

    public int ArrowsAmount => _yardProperties.ValueRO.arrowsAmount;
    public Entity ArrowPrefab => _yardProperties.ValueRO.arrowPrefab;

    //public UniformScaleTransform uniformScaleTransform

    // public LocalTransform UniformScaleTransform =>
    //     new()
    //     {
    //         Position = _localTransform.ValueRO.Position,
    //         Rotation = quaternion.identity,
    //         Scale    = 1f
    //     };

    public float3 GetRandomPosition()
    {
        var random = _yardRandom.ValueRW.Value.NextFloat3(-10, 10);
        return random;
    }

    // private float3 MinCorner => _localTransform.ValueRO.Position - GetHalphDimettion;
    // private float3 MaxCorner => _localTransform.ValueRO.Position + GetHalphDimettion;

    // private float3 GetHalphDimettion => new() 
    // {
    //     x = _yardProperties.ValueRO.filedSize.x * 0.5f,
    //     y = 0,
    //     z = _yardProperties.ValueRO.filedSize.y * 0.5f,
    // };
}
