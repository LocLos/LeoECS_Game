using Leopotam.EcsLite;
using UnityEngine;

public class CollisionCheckerView : MonoBehaviour
{
    public EcsWorld ecsWorld { get; set; }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var hit = ecsWorld.NewEntity();
        var hitPool = ecsWorld.GetPool<HitComponent>();
        hitPool.Add(hit);
        ref var hitComponent = ref hitPool.Get(hit);

        hitComponent.First = transform.root.gameObject;
        hitComponent.Other = other.gameObject;
    }
}
