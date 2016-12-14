using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameStates : NetworkBehaviour
{
    [SerializeField] private StartGame _startGameScript;
    [SerializeField] private RunningMiniGame _runningMiniGameScript;

    [SyncVar] private bool _gameStarted;
    [SyncVar] private bool _runningMiniGame;

    public bool GetGameStartBool
    {
        get { return _gameStarted; }
    }

    public bool GetRunningMiniGameBool
    {
        get { return _runningMiniGame; }
    }

    public delegate void GameStateEventHandler();
    public GameStateEventHandler OnGameStarted;
    public GameStateEventHandler OnMiniGameStarted;


    void Start()
    {
        _startGameScript.OnGameStart += StartGame;
        _runningMiniGameScript.OnMiniGameStart += RunMiniGame;
    }

    void StartGame()
    {
        if (OnGameStarted != null)
            OnGameStarted();

        _gameStarted = true;
    }

    void RunMiniGame()
    {
        if (OnMiniGameStarted != null)
            OnMiniGameStarted();

        _runningMiniGame = true;
    }
}
