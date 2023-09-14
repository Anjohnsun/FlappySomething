using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSwitcher
{
    private IGameState _currentGameState;
    private Dictionary<Type, IGameState> _states;

    public GameStateSwitcher(params IGameState[] states)
    {
        _states = new Dictionary<Type, IGameState>();

        foreach (IGameState newState in states)
        {
            _states.Add(newState.GetType(), newState);
        }

        SwitchGameState(typeof(StartScreenState));
    }

    public void SwitchGameState(Type nextState)
    {
        if (_states.ContainsKey(nextState) && nextState != _currentGameState?.GetType())
        {
            _currentGameState?.Exit();
            _currentGameState = _states[nextState];
            _currentGameState.Enter();
        }
    }
}
