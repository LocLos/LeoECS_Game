using Leopotam.EcsLite;
using TMPro;
using UnityEngine;


public class Startup : MonoBehaviour
{

    private EcsWorld ecsWorld;
    private IEcsSystems initSystems;
    private IEcsSystems updateSystems;
    // private IEcsSystems fixedUpdateSystems;
    [SerializeField] private ConfigurationSO configuration;
    [SerializeField] private TMP_Text coinCounter;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject playerWonPanel;

    private void Start()
    {
        ecsWorld = new EcsWorld();
        var gameData = new GameData(configuration, coinCounter);

       /* PlayerInputSystem playerInputSystem = new PlayerInputSystem();
        PlayerTakeCoinSystem playerTakeCoinSystem = new PlayerTakeCoinSystem();
        PlayerMovingSystem playerMovingSystem = new PlayerMovingSystem();*/
        /* gameData.gameOverPanel = gameOverPanel;
         gameData.playerWonPanel = playerWonPanel;
         gameData.sceneService = Service<SceneService>.Get(true);*/

        initSystems = new EcsSystems(ecsWorld, gameData)
           /*  .Add(playerInputSystem)
             .Add(playerTakeCoinSystem)
             .Add(playerMovingSystem)*/
             .Add(new PlayerInitSystem());
        // .Add(new DangerousInitSystem());


        updateSystems = new EcsSystems(ecsWorld, gameData)
            .Add(new PlayerInputSystem())
            .Add(new PlayerTakeCoinSystem())
            .Add(new PlayerMovingSystem());
        /* .Add(new DangerousRunSystem())
         .Add(new BuffHitSystem())
         .Add(new DangerousHitSystem())
         .Add(new WinHitSystem())
     .Add(new SpeedBuffSystem())
         .Add(new JumpBuffSystem())
         .DelHere<HitComponent>();*/
        initSystems.Init();
        updateSystems.Init();

    }

    private void Update()
    {
        updateSystems.Run();
    }

    private void OnDestroy()
    {
        initSystems.Destroy();
        updateSystems.Destroy();
        //  fixedUpdateSystems.Destroy();
        ecsWorld.Destroy();
    }
}
