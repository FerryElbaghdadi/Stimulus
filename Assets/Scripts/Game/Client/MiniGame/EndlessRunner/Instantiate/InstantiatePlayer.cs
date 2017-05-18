using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class InstantiatePlayer : NetworkBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;

    [SerializeField] private GameObject _playerObject;
    [SerializeField] private Transform _playerTransform;

    [SerializeField] private int _miniGameID;

    private bool _runOnce;

    void Start()
    {
        if (_miniGameID == 1)
        _gameStatesScript.OnMiniGameOneStarted += CmdPlayerActivate;
        else if (_miniGameID == 2)
            _gameStatesScript.OnMiniGameTwoStarted += CmdPlayerActivate;
        else if (_miniGameID == 3)
            _gameStatesScript.OnMiniGameThreeStarted += CmdPlayerActivate;
        else if (_miniGameID == 4)
            _gameStatesScript.OnMiniGameFourStarted += CmdPlayerActivate;
    }

    [Command]
    void CmdPlayerActivate()
    {
        if (!_runOnce)
        {
            _playerObject.transform.position = _playerTransform.position;

            _runOnce = true;

            RpcPlayerSetActive();
        }


        _runOnce = false;

        
    }

    [ClientRpc]
    void RpcPlayerSetActive()
    {
        _playerObject.SetActive(true);
    }
}
