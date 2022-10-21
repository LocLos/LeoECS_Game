using Leopotam.EcsLite;
using UnityEngine;

public class PlayerInputSystem : IEcsInitSystem, IEcsRunSystem
{
    private GameData _gameData;
     private EcsFilter _filter;
     private EcsPool<PlayerInputComponent> _playerInputPool;

    public void Init(IEcsSystems systems)
    {
        _filter = systems.GetWorld().Filter<PlayerInputComponent>().End();
        _playerInputPool = systems.GetWorld().GetPool<PlayerInputComponent>();
        _gameData = systems.GetShared<GameData>();
         //  var tryJumpPool = systems.GetWorld().GetPool<TryJump>();
    }

    public void Run(IEcsSystems systems)
    {
    
        foreach (var entity in _filter)
        {
            ref var playerInputComponent = ref _playerInputPool.Get(entity);

            playerInputComponent.Direction = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));

            /*  if (Input.GetKeyDown(KeyCode.Space))
              {
                  var tryJump = systems.GetWorld().NewEntity();
                  tryJumpPool.Add(tryJump);
              }

              if (Input.GetKeyDown(KeyCode.R))
              {
                  gameData.sceneService.ReloadScene();
              }*/
        }
    }
}

