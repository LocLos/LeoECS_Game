using UnityEngine;

public class EnemySpawnPoints : MonoBehaviour
{
    [SerializeField]
    private EnemyPointConfig[] _enemyConfig;
    private Factory _factory;

    public void Construct(Factory factory) =>
        _factory = factory;

    private void Start()
    {
        foreach (EnemyPointConfig enemyConfig in _enemyConfig)
        {
            _factory.CreateEnemy(enemyConfig, enemyConfig.transform);
        }
    }
}