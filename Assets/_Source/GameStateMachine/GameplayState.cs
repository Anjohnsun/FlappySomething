using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameplayState : IGameState
{
    private FlappyThingMovement _flappyMovement;


    public GameplayState(FlappyThingMovement flappyThingMovement)
    {
        _flappyMovement = flappyThingMovement;
    }

    public void Enter()
    {
        _flappyMovement.UnlockMovement(true);
        _flappyMovement.ReturnToStartPosition();
    }

    public void Exit()
    {
        _flappyMovement.UnlockMovement(false);
    }
}