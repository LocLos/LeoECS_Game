using Leopotam.EcsLite;
using UnityEngine;

public class PlayerTakeCoinSystem : IEcsInitSystem, IEcsRunSystem
{
    private GameData _gameData;
    private EcsFilter _hitFilter;
    private EcsPool<HitComponent> _hitPool;

    public void Init(IEcsSystems systems)
    {
        _gameData = systems.GetShared<GameData>();
        _hitFilter = systems.GetWorld().Filter<HitComponent>().End();
        _hitPool = systems.GetWorld().GetPool<HitComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var hitEntity in _hitFilter)
        {
            ref var hitComponent = ref _hitPool.Get(hitEntity);

            if (hitComponent.Other.CompareTag(Tags.CoinTag))
            {
                _gameData.AddCoin();
                GameObject.Destroy(hitComponent.Other.gameObject);
                systems.GetWorld().DelEntity(hitEntity);

            }

        }
    }
}

