using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

/*
 * This script takes care of all different states of the game.
 * With this other scripts are able to check the game's current state.
 */


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
    private int _addValue = 1;

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


    private void Start()
    {
        _startGameScript.OnGameStart += StartGame;
        _runningMiniGameScript.OnMiniGameStart += RunMiniGame;
        _miniGameCountdownScript.OnMiniGameCountEnd += StopMiniGame;

        _fadeToSceneTwoScript.OnFadeOut += StartSceneTwo;
        _fadeToSceneThreeScript.OnFadeOut += StartSceneThree;
        _fadeToFinalSceneScript.OnFadeOut += StartFinalScene;
        
       /*
        * All functions that will be called by the delegates.
        */

    }

    void StartGame()
    {
        if (OnGameStarted != null)
            OnGameStarted();

        _gameStarted = true;
        _runningGame = true;
        _preGame = false;
        
        /*
         * Once we start the game, we leave our _preGame state and enter our _gameStarted state.
         * _runningGame will keep on running until we leave our session.
         */
    }

    void RunMiniGame()
    {
        if (!_runningMiniGame)
        {
            _miniGame += _addValue;
            _runningMiniGame = true;
        }
        
        switch (_miniGame)
        {
            case 1:
                if (OnMiniGameOneStarted != null)
                OnMiniGameOneStarted();
                break;
            
            case 2:
                if (OnMiniGameTwoStarted != null)
                OnMiniGameTwoStarted();
                break;
            
            case 3:
                if (OnMiniGameThreeStarted != null)
                OnMiniGameThreeStarted();
                break;
            
            case 4:
                if (OnMiniGameFourStarted != null)
                OnMiniGameFourStarted();
                break;
        }

        if (OnMiniGameStarted != null)
            OnMiniGameStarted();
  
        _runningGame = false;
    }

    void StopMiniGame()
    {
        if (OnMiniGameEnd != null)
            OnMiniGameEnd();
            
        switch (_miniGame)
        {
            case 1:
                if (OnMiniGameOneEnd != null)
                OnMiniGameOneEnd();
                break;
            
            case 2:
                if (OnMiniGameTwoEnd != null)
                OnMiniGameTwoEnd();
                break;
            
            case 3:
                if (OnMiniGameThreeEnd != null)
                OnMiniGameThreeEnd();
                break;
            
            case 4:
                if (OnMiniGameFourEnd != null)
                OnMiniGameFourEnd();
                break;
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
