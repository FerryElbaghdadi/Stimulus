using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerCapabilities : NetworkBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;
    [SerializeField] private PlayerStates _playerStatesScript;

    [SerializeField] private PlayerJump _playerJumpScript;

    private bool _runOnce;

    void Awake()
    {
        CheckIsLocal();
    }

    void Start()
    {
        _gameStatesScript.OnMiniGameOneStarted += RestoreCapabilities;
       // _playerStatesScript.OnPlayerAir += () => _playerJumpScript.GetSetAbleToJump = false;
        _playerStatesScript.OnPlayerDeath += DisableJump;
    }

    void RestoreCapabilities()
    {
        if (!_runOnce)
        {
            _playerJumpScript.GetSetAbleToJump = true;
        }
        _runOnce = false;
    }

    void DisableJump()
    {
        _playerJumpScript.GetSetAbleToJump = false;
    }

    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }
}
