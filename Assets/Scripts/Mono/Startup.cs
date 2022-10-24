using Leopotam.EcsLite;
using TMPro;
using UnityEngine;


public class Startup : MonoBehaviour
{
    private EcsWorld _ecsWorld;
    private IEcsSystems _initSystems;
    private IEcsSystems _updateSystems;
    [SerializeField] private ConfigurationSO _configuration;
    [SerializeField] private TMP_Text _coinCounter;

    private Factory _factory;
    private GameData _gameData;

    private void Start()
    {
        CreateInfrastructer();

        AddInitSystem();
        AddUpdateSystem();

        _initSystems.Init();
        _updateSystems.Init();
    }

    private void CreateInfrastructer()
    {
        _ecsWorld = new EcsWorld();
        _factory = new Factory(_ecsWorld);
        _gameData = new GameData(_configuration, _coinCounter);
    }

    private void AddInitSystem()
    {
        _initSystems = new EcsSystems(_ecsWorld, _gameData)
             .Add(new PlayerInitSystem());
    }

    private void AddUpdateSystem()
    {
        _updateSystems = new EcsSystems(_ecsWorld, _gameData)
            .Add(new PlayerInputSystem())
            .Add(new PlayerTakeCoinSystem())
            .Add(new EnemyMovingSystem())
            .Add(new PlayerMovingSystem());
    }

    private void Update() => 
        _updateSystems.Run();

    private void OnDestroy()
    {
        _initSystems.Destroy();
        _updateSystems.Destroy();
        _ecsWorld.Destroy();
    }
}
