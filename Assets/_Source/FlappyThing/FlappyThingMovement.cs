using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyThingMovement : MonoBehaviour
{
    [SerializeField] private Vector2 _startPosition;

    [SerializeField] private float _riseFallSpeed;
    private float _verticalSpeed;

    private static bool _canMove = false;
    private bool _isRising = false;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Player.Click.performed += context => MakeFlappyThingRise(true);
        _playerInput.Player.Click.canceled += context => MakeFlappyThingRise(false);
        ReturnToStartPosition();
    }

    private void Update()
    {
        if (_canMove)
        {
            _verticalSpeed += _isRising ? _riseFallSpeed * Time.deltaTime : -_riseFallSpeed * Time.deltaTime;
            transform.position = new Vector2(transform.position.x, transform.position.y + _verticalSpeed * Time.deltaTime);
        }
    }

    private void MakeFlappyThingRise(bool value)
    {
        _isRising = value;
    }

    public void UnlockMovement(bool value)
    {
        _canMove = value;
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public void ReturnToStartPosition()
    {
        transform.position = _startPosition;
        _verticalSpeed = 0;
    }
}
