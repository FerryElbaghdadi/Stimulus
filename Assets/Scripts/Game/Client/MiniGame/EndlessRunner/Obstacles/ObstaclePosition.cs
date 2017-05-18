using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ObstaclePosition : NetworkBehaviour
{

    [SerializeField] private SpawnStates _spawnStatesScript;


    [SerializeField] private Transform[] _stoneTransforms;
    [SerializeField] private Transform[] _airTransforms;

    /*
    void Awake()
    {
        _obstacleVector = new Vector2(Random.Range(_minObstacleSpeed, _maxObstacleSpeed), 0);
    }

    void Start()
    {
        _thisRigidbody2D.velocity = _obstacleVector;

        _spawnStatesScript.OnReturnSpawn += () => _obstacleVector = new Vector2(Random.Range(_minObstacleSpeed, _maxObstacleSpeed), 0);
        _spawnStatesScript.OnReturnSpawn += () => _thisRigidbody2D.velocity = _obstacleVector;
    }
    */
}