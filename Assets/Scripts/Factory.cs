using Leopotam.EcsLite;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
public class Factory// разбить наследниками
{
    private EcsWorld _ecsWorld;
    private GameObject _player;

    public Factory(EcsWorld ecsWorld)
    {
        _ecsWorld = ecsWorld;
        CreatePlayer();
        CreateEnemySpawner();
    }

    public void CreatePlayer() =>
        _player = Object.Instantiate(Resources.Load(AddresPath.PlayerPref)) as GameObject;

    public void CreateEnemySpawner()
    {
        Object.Instantiate(Resources.Load(AddresPath.EnemySpawners))
            .GetComponent<EnemySpawnPoints>()
             .Construct(this); // разделить
    }

    public Object CreateEnemy(EnemyPointConfig enemyConfig, Transform point)
    {
        var entity = _ecsWorld.NewEntity();
        var enemyPool = _ecsWorld.GetPool<EnemyComponent>();

        enemyPool.Add(entity);
        ref var enemyComponent = ref enemyPool.Get(entity);
        enemyComponent.Speed = enemyConfig.MoveSpeed;

        GameObject enemy = Object.Instantiate(
             Resources.Load(enemyConfig.Type.ToString())
             , point.position
             , Quaternion.identity) as GameObject; // поменять на аддресейблы
        enemyComponent.Transform = enemy.transform;
        enemyComponent.TargetTransform = _player.transform;
        return enemy;
    }


}
