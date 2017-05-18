using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class InstantiateBackground : NetworkBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;

    [SerializeField] private GameObject _backgroundObject;
    [SerializeField] private Transform _backgroundTransform;

     [SerializeField] private int _miniGameID;

    private bool _runOnce;

    void Start()
    {
        if (_miniGameID == 1)
            _gameStatesScript.OnMiniGameOneStarted += CmdBackgroundActivate;
        else if (_miniGameID == 2)
            _gameStatesScript.OnMiniGameTwoStarted += CmdBackgroundActivate;
        else if (_miniGameID == 3)
            _gameStatesScript.OnMiniGameThreeStarted += CmdBackgroundActivate;
        else if (_miniGameID == 4)
            _gameStatesScript.OnMiniGameFourStarted += CmdBackgroundActivate;
    }

    [Command]
    void CmdBackgroundActivate()
    {
        if (!_runOnce)
            _backgroundObject.transform.position = _backgroundTransform.position;

        _runOnce = true;

        RpcBackgroundSetActive();
    }

    [ClientRpc]
    void RpcBackgroundSetActive()
    {
        _backgroundObject.SetActive(true);
    }

}
