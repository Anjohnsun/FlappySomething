using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Vector2 point1;
    [SerializeField] private Vector2 point2;

    [SerializeField] private bool _isActiveObstacle;
    [SerializeField] private int _playerLayer;

    [Inject]
    private GameStateSwitcher _gameStateSwitcher;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.layer == _playerLayer) {
            _gameStateSwitcher.SwitchGameState(new StartScreenState(new GameObject(), new PointCounter(new TextMeshProUGUI()))); //да да шакально согласен
        }
    }
}
