using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenState : IGameState
{
    private PointCounter _pointCounter;

    public void Enter() {
        _pointCounter.ResetPoints();
    }

    public void Exit() {

    }
}
