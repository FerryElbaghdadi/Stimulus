using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class GameStates : NetworkBehaviour
{

    [SerializeField] private StartGame _startGameScript;
    [SerializeField] private RunningMiniGame _runningMiniGameScript;
    [SerializeField] private MiniGameCountdown _miniGameCountdownScript;

    [SerializeField] private FadeToSceneTwo _fadeToSceneTwoScript;
    [SerializeField] private FadeToSceneThree _fadeToSceneThreeScript;
    [SerializeField] private FadeToFinalScene _fadeToFinalSceneScript;


    [SyncVar] private bool _preGame = true;
    [SyncVar] private bool _gameStarted;
    [SyncVar] private bool _runningGame;
    [SyncVar] private bool _runningMiniGame;

    private int _miniGame;

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
    public GameStateEventHandler OnMiniGameOneStarted;
    public GameStateEventHandler OnMiniGameTwoStarted;
    public GameStateEventHandler OnMiniGameThreeStarted;
    public GameStateEventHandler OnMiniGameFourStarted;

    public GameStateEventHandler OnMiniGameEnd;
    public GameStateEventHandler OnMiniGameOneEnd;
    public GameStateEventHandler OnMiniGameTwoEnd;
    public GameStateEventHandler OnMiniGameThreeEnd;
    public GameStateEventHandler OnMiniGameFourEnd;

    public GameStateEventHandler OnSceneOneEnd;
    public GameStateEventHandler OnSceneTwoEnd;
    public GameStateEventHandler OnSceneThreeEnd;


    void Start()
    {
        _startGameScript.OnGameStart += StartGame;
        _runningMiniGameScript.OnMiniGameStart += RunMiniGame;
        _miniGameCountdownScript.OnMiniGameCountEnd += StopMiniGame;

        _fadeToSceneTwoScript.OnFadeOut += StartSceneTwo;
        _fadeToSceneThreeScript.OnFadeOut += StartSceneThree;
        _fadeToFinalSceneScript.OnFadeOut += StartFinalScene;

    }

    void StartGame()
    {
        if (OnGameStarted != null)
            OnGameStarted();

        _gameStarted = true;
        _runningGame = true;
        _preGame = false;
    }

    void RunMiniGame()
    {
        

        if (!_runningMiniGame)
        {
            _miniGame += 1;
            _runningMiniGame = true;
        }
        

        if (_miniGame == 1)
        {
            if (OnMiniGameOneStarted != null)
                OnMiniGameOneStarted();
        }

        else if (_miniGame == 2)
        {
            if (OnMiniGameTwoStarted != null)
                OnMiniGameTwoStarted();
        }

        else if (_miniGame == 3)
        {
            if (OnMiniGameThreeStarted != null)
                OnMiniGameThreeStarted();
        }

        else if (_miniGame == 4)
        {
            if (OnMiniGameFourStarted != null)
                OnMiniGameFourStarted();
        }

        if (OnMiniGameStarted != null)
            OnMiniGameStarted();

        
        _runningGame = false;
    }

    void StopMiniGame()
    {
        if (OnMiniGameEnd != null)
            OnMiniGameEnd();

        if (_miniGame == 1)
        {
            if (OnMiniGameOneEnd != null)
                OnMiniGameOneEnd();
        }

        else if (_miniGame == 2)
        {
            if (OnMiniGameTwoEnd != null)
                OnMiniGameTwoEnd();
        }

        else if (_miniGame == 3)
        {
            if (OnMiniGameThreeEnd != null)
                OnMiniGameThreeEnd();
        }

        else if (_miniGame == 4)
        {
            if (OnMiniGameFourEnd != null)
                OnMiniGameFourEnd();
        }

        _runningGame = true;
        _runningMiniGame = false;
    }

    void StartSceneTwo()
    {
        if (OnSceneOneEnd != null)
            OnSceneOneEnd();
    }

    void StartSceneThree()
    {
        if (OnSceneTwoEnd != null)
            OnSceneTwoEnd();
    }

    void StartFinalScene()
    {
        if (OnSceneThreeEnd != null)
            OnSceneThreeEnd();
    }
} 
