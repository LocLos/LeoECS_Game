using Leopotam.EcsLite;
using UnityEngine;

public class PlayerMovingSystem : IEcsInitSystem, IEcsRunSystem
{
     private EcsFilter _filter;
     private EcsPool<PlayerComponent> _playerPool;
     private EcsPool<PlayerInputComponent> _playerInputPool;

    public void Init(IEcsSystems systems)
    {
         _filter = systems.GetWorld().Filter<PlayerComponent>().Inc<PlayerInputComponent>().End();
         _playerPool = systems.GetWorld().GetPool<PlayerComponent>();
         _playerInputPool = systems.GetWorld().GetPool<PlayerInputComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var playerComponent = ref _playerPool.Get(entity);
            ref var playerInputComponent = ref _playerInputPool.Get(entity);
            playerComponent.PlayerTransform.Translate(playerInputComponent.Direction * playerComponent.PlayerSpeed * Time.deltaTime);
        }
    }
}

