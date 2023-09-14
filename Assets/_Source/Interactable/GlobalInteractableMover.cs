using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInteractableMover : MonoBehaviour
{
    private static bool _canMove;
    public static List<Transform> _transforms;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _speedBostPerSecond;
    private float _currentSpeed;

    private void Start()
    {
        _currentSpeed = _moveSpeed;
    }

    private void Update()
    {
        if (_canMove)
        {
            foreach (Transform transform in _transforms)
            {
                transform.position = new Vector3(transform.position.x - _currentSpeed * Time.deltaTime, transform.position.y);
            }
        }
        _moveSpeed += _speedBostPerSecond * Time.deltaTime;
    }

    public void UnlockMovement(bool def)
    {
        _canMove = def;
        _currentSpeed = _moveSpeed;
    }
}
