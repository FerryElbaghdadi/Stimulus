using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ObstacleMovement : NetworkBehaviour
{

    [SerializeField] private GameStates _gameStatesScript;

    [SerializeField] private Rigidbody2D _thisRigidbody2D;

    [SyncVar] [SerializeField] private float _obstacleSpeed;

    [SyncVar] [SerializeField] private Vector2 _obstacleVector;


    void Start()
    {
        _obstacleVector = new Vector2(_obstacleSpeed, 0);

        _thisRigidbody2D.velocity = _obstacleVector;
    }
}