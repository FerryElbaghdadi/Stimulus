using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class InstantiateObstacle : NetworkBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;

    [SerializeField] private GameObject[] _obstacleObjects;
    [SerializeField] private Transform _obstacleTransform;

     [SerializeField] private int _miniGameID;

    private bool _runOnce;

    void Start()
    {
        if (_miniGameID == 1)
            _gameStatesScript.OnMiniGameOneStarted += CmdObstacleActivate;
        else if (_miniGameID == 2)
            _gameStatesScript.OnMiniGameTwoStarted += CmdObstacleActivate;
        else if (_miniGameID == 3)
            _gameStatesScript.OnMiniGameThreeStarted += CmdObstacleActivate;
        else if (_miniGameID == 4)
            _gameStatesScript.OnMiniGameFourStarted += CmdObstacleActivate;
    }

    [Command]
    void CmdObstacleActivate()
    {
        if (!_runOnce)
        {
         //   _playerObject.transform.position = _playerTransform.position;
            RpcObstacleSetActive();

            _runOnce = true;
        }

        _runOnce = false;
    }

    [ClientRpc]
    void RpcObstacleSetActive()
    {
        foreach (GameObject obstacle in _obstacleObjects)
            obstacle.SetActive(true);
    }
}
