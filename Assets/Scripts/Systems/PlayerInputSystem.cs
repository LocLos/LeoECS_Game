using Leopotam.EcsLite;
using UnityEngine;

public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _filter;
    private EcsPool<PlayerInputComponent> _playerInputPool;

    public void Init(IEcsSystems systems)
    {
        _filter = systems.GetWorld().Filter<PlayerInputComponent>().End();
        _playerInputPool = systems.GetWorld().GetPool<PlayerInputComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var playerInputComponent = ref _playerInputPool.Get(entity);

            playerInputComponent.Direction = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));
        }
    }
}

