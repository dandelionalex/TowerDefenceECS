using Unity.Entities;
using Unity.Mathematics;

public readonly partial struct YardAspect : IAspect
{
    public readonly Entity Entity;

    private readonly RefRO<YardComponent> _yardComponent;
    private readonly RefRW<YardRandomComponent> _yardRandom;

    public int ArrowsAmount => _yardComponent.ValueRO.arrowsAmount;
    public Entity ArrowPrefab => _yardComponent.ValueRO.arrowPrefab;

    public float3 GetRandomPosition()
    {
        var random = _yardRandom.ValueRW.Value.NextFloat3(MinCorner, MaxCorner);
        return random;
    }

    private float3 MinCorner => _yardComponent.ValueRO.filedCenter - GetHalphDimettion;
    private float3 MaxCorner => _yardComponent.ValueRO.filedCenter + GetHalphDimettion;

    private float3 GetHalphDimettion => new() 
    {
        x = _yardComponent.ValueRO.filedSize.x * 0.5f,
        y = 0,
        z = _yardComponent.ValueRO.filedSize.y * 0.5f,
    };
}
