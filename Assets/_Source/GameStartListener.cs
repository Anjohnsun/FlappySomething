using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameStartListener : MonoBehaviour
{
    private PlayerInput _playerInput;
    [Inject]
    GameStateSwitcher _gameStateSwitcher;

    private void OnEnable() {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.Click.canceled += context => StartGame();
    }

    private void StartGame() {
        _gameStateSwitcher.SwitchGameState(new GameplayState(new FlappyThingMovement())); //да, это мерзко
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        _playerInput.Disable();
    }
}
