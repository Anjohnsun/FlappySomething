using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class VGameSceneInstaller : LifetimeScope
{
    [SerializeField] private FlappyThingMovement _flappyMovement;
    [SerializeField] private GameObject _startText;
    [SerializeField] private TextMeshProUGUI _pointField;

    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private GameStartListener _gameStartListener;

    [SerializeField] private GlobalInteractableMover _globalInteractableMover;
    [SerializeField] private Vector2 _obstacleSpawnPoint;
    [SerializeField] private float _verticalSpawnSpread;

    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);

        PointCounter pointCounter = new PointCounter(_pointField);

        GameplayState gameplayState = new GameplayState(_flappyMovement);
        StartScreenState startScreenState = new StartScreenState(_startText, pointCounter, _gameStartListener);

        GameStateSwitcher gameStateSwitcher = new GameStateSwitcher(startScreenState, gameplayState);

        InteractablesSpawner _obstacleSpawner = new InteractablesSpawner(_obstaclePrefab, this, _obstacleSpawnPoint, _verticalSpawnSpread);

        /*Container.Bind<GameStateSwitcher>().FromInstance(gameStateSwitcher).AsSingle();
        Container.Bind<PointCounter>().FromInstance(pointCounter).AsSingle();
        Container.Bind<FlappyThingMovement>().FromInstance(_flappyMovement).AsSingle();
        Container.Bind<InteractablesSpawner>().FromInstance(_obstacleSpawner).AsSingle();
        Container.Bind<GameStartListener>().FromInstance(_gameStartListener).AsSingle();
        Container.Bind<GlobalInteractableMover>().FromInstance(_globalInteractableMover).AsSingle();*/

        builder.RegisterEntryPoint<VBootstrapper>();

        builder.RegisterInstance(gameStateSwitcher);
        builder.RegisterInstance(pointCounter);
        builder.RegisterInstance(_flappyMovement);
        builder.RegisterInstance(_obstacleSpawner);
        builder.RegisterInstance(_gameStartListener);
        builder.RegisterInstance(_globalInteractableMover);
        Debug.Log("Done");
    }
}
