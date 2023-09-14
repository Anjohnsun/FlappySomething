using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStartListener : MonoBehaviour
{
    private PlayerInput _playerInput;
    [Inject]
    GameStateSwitcher _gameStateSwitcher;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Player.Click.canceled += context => StartGame();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void StartGame()
    {
        _gameStateSwitcher.SwitchGameState(typeof(GameplayState));
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
}
