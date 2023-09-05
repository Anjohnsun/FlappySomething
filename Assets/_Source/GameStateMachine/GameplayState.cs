using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayState : IGameState
{
    private FlappyThingMovement _flappyMovement;

    public GameplayState(FlappyThingMovement flappyThingMovement) {
        _flappyMovement = flappyThingMovement;
    }

    public void Enter() {
        _flappyMovement.LockMovement(false);
    }

    public void Exit() {
        _flappyMovement.LockMovement(true);
    }
}
