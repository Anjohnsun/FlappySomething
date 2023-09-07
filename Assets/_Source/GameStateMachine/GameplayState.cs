using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayState : IGameState
{
    private FlappyThingMovement _flappyMovement;
    [Inject]
    private InteractablesSpawner _spawner;

    public GameplayState(FlappyThingMovement flappyThingMovement) {
        _flappyMovement = flappyThingMovement;
    }

    public void Enter() {
        _flappyMovement.UnlockMovement(true);
        _spawner.StartSpawning(true);
    }

    public void Exit() {
        _flappyMovement.UnlockMovement(false);
        _spawner.StartSpawning(false);
    }
}
