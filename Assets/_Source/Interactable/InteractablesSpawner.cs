using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class InteractablesSpawner
{
    private GameObject _objectToSpawn;

    private MonoBehaviour _randomCoroutineObject;

    private Vector2 _spawnPoint;
    private float _verticalSpawnSpread;

    private float _delay;
    private float _delayRandomizer;

    public InteractablesSpawner(GameObject objectToSpawn, MonoBehaviour randomCoroutineObject, Vector2 spawnPoint, float verticaSpawnSpread)
    {
        _objectToSpawn = objectToSpawn;
        _randomCoroutineObject = randomCoroutineObject;
        _spawnPoint = spawnPoint;
        _verticalSpawnSpread = verticaSpawnSpread;
    }

    public void StartSpawning(bool conf)
    {
        if (conf)
            _randomCoroutineObject.StartCoroutine(SpawnInteractableCor());
        else
            _randomCoroutineObject.StopAllCoroutines();
    }

    private IEnumerator SpawnInteractableCor()
    {
        yield return new WaitForSeconds(_delay + Random.Range(0, 1) * _delayRandomizer);

        GameObject.Instantiate(_objectToSpawn, new Vector2(_spawnPoint.x, _spawnPoint.y + _verticalSpawnSpread * Random.Range(-1, 1)), new Quaternion());

        yield return _randomCoroutineObject.StartCoroutine(SpawnInteractableCor());
    }

}
