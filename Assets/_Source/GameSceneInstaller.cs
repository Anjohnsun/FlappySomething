using TMPro;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [SerializeField] private FlappyThingMovement _flappyMovement;
    [SerializeField] private GameObject _startText;
    [SerializeField] private TextMeshProUGUI _pointField;

    [SerializeField] private GameObject _obstaclePrefab;
    //private InteractablesSpawner[] _spawners;

    public override void InstallBindings() {
        PointCounter pointCounter = new PointCounter(_pointField);

        GameplayState gameplayState = new GameplayState(_flappyMovement);
        StartScreenState startScreenState = new StartScreenState(_startText, pointCounter);

        GameStateSwitcher gameStateSwitcher = new GameStateSwitcher(startScreenState, gameplayState);

        InteractablesSpawner _obstacleSpawner = new InteractablesSpawner(_obstaclePrefab, this);
        //_spawners = new InteractablesSpawner[] { _obstacleSpawner };

        Container.Bind<GameStateSwitcher>().FromInstance(gameStateSwitcher).AsSingle();
        Container.Bind<PointCounter>().FromInstance(pointCounter).AsSingle();
        Container.Bind<FlappyThingMovement>().FromInstance(_flappyMovement).AsSingle();
        Container.Bind<InteractablesSpawner>().FromInstance(_obstacleSpawner).AsSingle();
    }
}