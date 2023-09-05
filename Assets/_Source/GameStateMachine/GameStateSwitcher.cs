using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateSwitcher : MonoBehaviour
{
    private IGameState _currentGameState;
    private GameplayState _gameplayState;
    private StartScreenState _startCreenState;

    private void Start() {
        
    }

    public void SwitchGameState(IGameState newGameState) {

        if(_currentGameState.GetType() != newGameState.GetType()) {
            
            _currentGameState.Exit();
            _currentGameState = newGameState;
            _currentGameState.Enter();

        }

    }
    
}
