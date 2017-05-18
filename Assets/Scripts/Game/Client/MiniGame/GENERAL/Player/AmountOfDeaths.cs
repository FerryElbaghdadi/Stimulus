using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AmountOfDeaths : NetworkBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;
    [SerializeField] private PlayerStates _playerStatesScript;

    [SyncVar] [SerializeField] private int _playerDeaths;

    public int GetPlayerDeaths
    {
        get { return _playerDeaths; }
    }

    private int _amountAdded = 1;

    public delegate void AmountOfDeathEventHandler();
    public AmountOfDeathEventHandler OnPlayerDeath;

    void Start()
    {
        _gameStatesScript.OnMiniGameStarted += () => _playerDeaths = 0;
        _playerStatesScript.OnPlayerDeath += AddPlayerDeath;
    }

    void AddPlayerDeath()
    {
        _playerDeaths += _amountAdded;

        if (OnPlayerDeath != null)
            OnPlayerDeath();
    }
}
