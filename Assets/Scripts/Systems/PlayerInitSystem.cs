using Leopotam.EcsLite;
using UnityEngine;

public class PlayerInitSystem : IEcsInitSystem
{
    public void Init(IEcsSystems systems)
    {
        var ecsWorld = systems.GetWorld();
        var gameData = systems.GetShared<GameData>();
        var playerEntity = ecsWorld.NewEntity();

        var playerPool = ecsWorld.GetPool<PlayerComponent>();

        playerPool.Add(playerEntity);
        ref var playerComponent = ref playerPool.Get(playerEntity);
        var playerInputPool = ecsWorld.GetPool<PlayerInputComponent>();
        playerInputPool.Add(playerEntity);
        ref var playerInputComponent = ref playerInputPool.Get(playerEntity);

        var playerGO = GameObject.FindGameObjectWithTag("Player");// СОЗДАВАТЬ ЧЕРЕЗ ФАБРИКУ?
        playerGO.GetComponentInChildren<CollisionCheckerView>().ecsWorld = ecsWorld;
      /*  
       playerGO.GetComponentInChildren<GroundCheckerView>().groundedPool = systems.GetWorld().GetPool<GroundedComponent>();
        playerGO.GetComponentInChildren<GroundCheckerView>().playerEntity = playerEntity;
      */
        playerComponent.PlayerSpeed = gameData.Configuration.PlayerSpeed;
        playerComponent.PlayerTransform = playerGO.transform;
      //  playerComponent.playerJumpForce = gameData.configuration.playerJumpForce;
        playerComponent.PlayerCollider = playerGO.GetComponent<CapsuleCollider>();
       // playerComponent.playerRB = playerGO.GetComponent<Rigidbody>();
    }
}
