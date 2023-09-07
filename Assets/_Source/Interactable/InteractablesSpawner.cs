using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InteractablesSpawner
{
    private GameObject _objectToSpawn;
    /*    private Vector2 _startOffset;
        private Vector2[] _moveToPoints;
        private bool _moveRandomly;*/

    private MonoBehaviour _randomCoroutineObject;

    private float _delay;
    private float _delayRandomizer;

    [Inject]
    private FlappyThingMovement _flappyMovement;

    public InteractablesSpawner(GameObject objectToSpawn,/* Vector2[] moveToPoints, bool moveRandomly,*/ MonoBehaviour randomCoroutineObject) {
        _objectToSpawn = objectToSpawn;
        /*        _startOffset = startOffset;
                _moveToPoints = moveToPoints;
                _moveRandomly = moveRandomly;*/
        _randomCoroutineObject = randomCoroutineObject;
    }

    public void StartSpawning(bool conf) {
        if (conf)
            _randomCoroutineObject.StartCoroutine("SpawnInteractableCor");
        else
            _randomCoroutineObject.StopAllCoroutines();
    }

    private IEnumerator SpawnInteractableCor() {
        yield return new WaitForSeconds(_delay + Random.Range(0, 1) * _delayRandomizer);

        GameObject.Instantiate(_objectToSpawn, new Vector2(_flappyMovement.transform.position.x + 10, Random.Range(-3, 3)), new Quaternion());
        //тут я понял, что не разобрался с динамическим внедрением

        yield return _randomCoroutineObject.StartCoroutine("SpawnInteractableCor");
    }



}
