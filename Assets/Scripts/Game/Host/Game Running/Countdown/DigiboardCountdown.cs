using UnityEngine;
using System.Collections;

public class DigiboardCountdown : MonoBehaviour
{

    [SerializeField] private GameStates _gameStatesScript;
    [SerializeField] private TriggerMiniGameOne _triggerMiniGameOneScript;
    [SerializeField] private TriggerMiniGameTwo _triggerMiniGameTwoScript;
    [SerializeField] private TriggerMiniGameThree _triggerMiniGameThreeScript;
    [SerializeField] private TriggerMiniGameFour _triggerMiniGameFourScript;

    [SerializeField] private float _countDownAmount;
    [SerializeField] private float _timeSubtracter = 1f;

    public float GetCountDown
    {
        get { return _countDownAmount; }
    }

    private bool _startCountdown;

    public delegate void CountdownEventHandler();
    public CountdownEventHandler OnCountdown;
    public CountdownEventHandler OnEndCountdown;

    void Start()
    {
        _gameStatesScript.OnMiniGameEnd += () => _countDownAmount = 3f;
        _gameStatesScript.OnMiniGameEnd += () => _startCountdown = false;

        _triggerMiniGameOneScript.OnTriggerTram += StartCount;
        _triggerMiniGameTwoScript.OnTriggerTourists += StartCount;
        _triggerMiniGameThreeScript.OnTriggerBaby += StartCount;
        _triggerMiniGameFourScript.OnTriggerScanner += StartCount;
    }

    void Update()
    {
        if (_startCountdown)
           CountDown();            
    }

    void StartCount()
    {
            _startCountdown = true;
    }

    void CountDown()
    {
       if (_countDownAmount >= Mathf.Abs(0))
        {
            _countDownAmount -= _timeSubtracter * Time.deltaTime;

            if (OnCountdown != null)
                OnCountdown();
        }

        else
        {
            if (OnEndCountdown != null)
                OnEndCountdown();
        }
    }
}
