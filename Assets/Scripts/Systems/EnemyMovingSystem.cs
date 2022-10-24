using Leopotam.EcsLite;
using UnityEngine;

public class EnemyMovingSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _filter;
    private EcsPool<EnemyComponent> _enemyPool;

    public void Init(IEcsSystems systems)
    {
        _filter = systems.GetWorld().Filter<EnemyComponent>().End();
        _enemyPool = systems.GetWorld().GetPool<EnemyComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var enemyComponent = ref _enemyPool.Get(entity);

            enemyComponent.Transform.position = Vector2.MoveTowards(
                enemyComponent.Transform.position,
                enemyComponent.TargetTransform.position,
                enemyComponent.Speed * Time.deltaTime);
        }
    }
}
