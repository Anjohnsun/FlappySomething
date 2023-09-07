using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSwitcher
{
    private IGameState _currentGameState;
    private IGameState[] _states;

    public GameStateSwitcher(params IGameState[] states) {
        _states = states;
        _currentGameState = _states[0];
    }

    public void SwitchGameState(IGameState newGameState/*шакально, надо подумать*/) {

        if (_currentGameState.GetType() != newGameState.GetType()) {
            for (int i = 0; i < _states.Length; i++) {
                if (newGameState.GetType() == _states[i].GetType()) {
                    _currentGameState.Exit();
                    _currentGameState = newGameState;
                    _currentGameState.Enter();
                }
            }
        }

    }

}
