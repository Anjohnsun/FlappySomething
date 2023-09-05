using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartListener : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private GameObject _startText;
    GameStateSwitcher _gameStateSwitcher;

    private void OnEnable() {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.Click.canceled += context => StartGame();
    }

    private void StartGame() {
       // _gameStateSwitcher.SwitchGameState(new GameplayState());
       _startText.SetActive(false);
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        _playerInput.Disable();
    }

    public void OpenStartScreen() {
        _startText.SetActive(true);
        gameObject.SetActive(true);
    }
}
