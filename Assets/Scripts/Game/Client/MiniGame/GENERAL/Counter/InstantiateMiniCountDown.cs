using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class InstantiateMiniCountDown : NetworkBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;

    [SerializeField] private GameObject _textObject;

    private bool _runOnce;

    void Start()
    {
        _gameStatesScript.OnMiniGameOneStarted += CmdBackgroundActivate;
    }

    [Command]
    void CmdBackgroundActivate()
    {
        RpcBackgroundSetActive();
    }

    [ClientRpc]
    void RpcBackgroundSetActive()
    {
        _textObject.SetActive(true);
    }

}
