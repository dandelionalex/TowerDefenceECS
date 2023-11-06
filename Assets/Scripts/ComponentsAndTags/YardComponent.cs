using Unity.Entities;
using Unity.Mathematics;

public struct YardComponent : IComponentData
{
    public float2 filedSize;
    public int arrowsAmount;
    public Entity arrowPrefab;
}