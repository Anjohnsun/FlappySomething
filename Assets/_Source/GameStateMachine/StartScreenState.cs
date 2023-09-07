using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenState : IGameState
{
    private PointCounter _pointCounter;
    private GameObject _startText;

    public StartScreenState(GameObject startText, PointCounter pointCounter) {
        _startText = startText;
        _pointCounter = pointCounter;
    }

    public void Enter() {
        _pointCounter.ResetPoints();
        _startText.SetActive(true);
    }

    public void Exit() {
        _startText.SetActive(false);
    }
}
