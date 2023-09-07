using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleData", menuName = "ObstacleSO")]
public class InteractableSO : ScriptableObject
{
    [SerializeField] private GameObject _interactablePrefab;

}

