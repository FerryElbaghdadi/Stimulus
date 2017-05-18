using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class InstantiatePlatform : NetworkBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;

    [SerializeField] private GameObject _platformObject;
    [SerializeField] private Transform _platformTransform;

    [SerializeField] private int _miniGameID;

    private bool _runOnce;

    void Start()
    {
        if (_miniGameID == 1)
            _gameStatesScript.OnMiniGameOneStarted += CmdPlatformActivate;
        else if (_miniGameID == 2)
            _gameStatesScript.OnMiniGameTwoStarted += CmdPlatformActivate;
        else if (_miniGameID == 3)
            _gameStatesScript.OnMiniGameThreeStarted += CmdPlatformActivate;
        else if (_miniGameID == 4)
            _gameStatesScript.OnMiniGameFourStarted += CmdPlatformActivate;
    }

    [Command]
    void CmdPlatformActivate()
    {
        RpcPlatformSetActive();
    }

    [ClientRpc]
    void RpcPlatformSetActive()
    {
        _platformObject.SetActive(true);
    }
    
}
