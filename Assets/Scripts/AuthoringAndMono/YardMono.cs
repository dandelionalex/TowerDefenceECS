using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class YardMono : MonoBehaviour
{
    public float2 filedSize;
    public int arrowsAmount;
    public GameObject arrowPrefab;
    public uint randomSeed;

    public class YardBaker : Baker<YardMono>
    {
        public override void Bake(YardMono authoring)
        {
            var entity = GetEntity(TransformUsageFlags.None);
            
            AddComponent(entity, new YardComponent
                {
                    // By default, each authoring GameObject turns into an Entity.
                    // Given a GameObject (or authoring component), GetEntity looks up the resulting Entity.
                    arrowPrefab = GetEntity(authoring.arrowPrefab, TransformUsageFlags.Dynamic),
                    filedSize = authoring.filedSize,
                    arrowsAmount = authoring.arrowsAmount,
                });

            AddComponent (entity, 
                new YardRandomComponent { Value = Unity.Mathematics.Random.CreateFromIndex(authoring.randomSeed) });    
        }
    }
}
