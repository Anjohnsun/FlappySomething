using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class StartScreenState : IGameState
{
    private PointCounter _pointCounter;
    private GameObject _startText;
    private GameStartListener _gameStartListener;

    public StartScreenState(GameObject startText, PointCounter pointCounter, GameStartListener gameStartListener) {
        _startText = startText;
        _pointCounter = pointCounter;
        _gameStartListener = gameStartListener;
    }

    public void Enter() {
        _pointCounter.ResetPoints();
        _startText.SetActive(true);
        _gameStartListener.gameObject.SetActive(true);
    }

    public void Exit() {
        _startText.SetActive(false);
        _gameStartListener.gameObject.SetActive(false);
    }
}
