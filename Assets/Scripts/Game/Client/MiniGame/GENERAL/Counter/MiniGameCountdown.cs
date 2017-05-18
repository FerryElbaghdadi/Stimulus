using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MiniGameCountdown : NetworkBehaviour
{

    public delegate void MiniGameCountdownEventHandler();
    public MiniGameCountdownEventHandler OnMiniGameSecond;
    public MiniGameCountdownEventHandler OnMiniGameCountEnd;

    [SerializeField] private GameStates _gameStatesScript;

    [SyncVar] [SerializeField] private float _miniGameCountDown = 10f;
    [SerializeField] private float _timeMultiplier = 0.8f;

    private bool _runCountdown = true;

    private int _timesRun;

    public float GetMiniGameCountDown
    {
        get { return _miniGameCountDown; }
    }

    void Start()
    {
        _gameStatesScript.OnMiniGameOneStarted += MiniGameCountDown;
        _gameStatesScript.OnMiniGameTwoStarted += MiniGameCountDown;
        _gameStatesScript.OnMiniGameThreeStarted += MiniGameCountDown;
        _gameStatesScript.OnMiniGameFourStarted += MiniGameCountDown;
    }

    void ResetCounter()
    {
        _runCountdown = true;
        _miniGameCountDown = 10f;
       
    }

    void MiniGameCountDown()
    {

        if (_runCountdown)
        {

            if (_miniGameCountDown >= Mathf.Abs(0))
            {
                _miniGameCountDown -= _timeMultiplier * Time.deltaTime;

                if (OnMiniGameSecond != null)
                    OnMiniGameSecond();
            }
            else
            {
                if (OnMiniGameCountEnd != null)
                    OnMiniGameCountEnd();

                _runCountdown = false;
                ResetCounter();
            }
        }
    }
}