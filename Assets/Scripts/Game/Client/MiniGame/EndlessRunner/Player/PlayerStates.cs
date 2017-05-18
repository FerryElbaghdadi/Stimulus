using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerStates : NetworkBehaviour
{
    public delegate void PlayerStatesEventHandler();
    public PlayerStatesEventHandler OnPlayerGrounded;
    public PlayerStatesEventHandler OnPlayerAir;
    public PlayerStatesEventHandler OnPlayerDeath;

    [SerializeField] private GameStates _gameStatesScript;
    [SerializeField] private PlayerCollision _playerCollisionScript;
    [SerializeField] private PlayerTrigger _playerTriggerScript;

    [SerializeField] private bool _playerGrounded;

    private bool _runOnce;

    public bool GetPlayerGrounded
    {
        get { return _playerGrounded; }
    }


   [SyncVar] [SerializeField] private bool _playerDeath;

    public bool GetPlayerDeath
    {
        get { return _playerDeath; }
        set { _playerDeath = value; }
    }

    void Awake()
    {
        CheckIsLocal();
    }

    void Start()
    {
        _playerCollisionScript.OnPlayerGrounded += GroundedPlayer;
        _playerCollisionScript.OnPlayerAir += AirPlayer;

        _playerTriggerScript.OnPlayerObstacle += CmdDeathPlayer;
    }

    void GroundedPlayer()
    {
        _playerGrounded = true;

        if (OnPlayerGrounded != null)
            OnPlayerGrounded();
    }

    void AirPlayer()
    {
        _playerGrounded = false;

        if (OnPlayerAir != null)
            OnPlayerAir();
    }

    [Command]
    void CmdDeathPlayer()
    {
        RpcDeathPlayer();
    }

    [RPC]
    void RpcDeathPlayer()
    { 
        if (!_playerDeath)
        {

            if (OnPlayerDeath != null)
                OnPlayerDeath();
        }

        _playerDeath = true;
    }

    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }

}
