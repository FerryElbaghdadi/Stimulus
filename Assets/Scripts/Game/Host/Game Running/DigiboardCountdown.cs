using UnityEngine;
using System.Collections;

public class DigiboardCountdown : MonoBehaviour
{

    [SerializeField] private GameStates _gameStatesScript;

    [SerializeField] private float _countDownAmount;

    public float GetCountDown
    {
        get { return _countDownAmount; }
    }

    private bool _startCountdown;

    public delegate void CountdownEventHandler();
    public CountdownEventHandler OnCountdown;
    public CountdownEventHandler OnEndCountdown;

    void Update()
    {
        StartCount();

        if (_startCountdown)
        {
            if (_gameStatesScript.GetGameStartBool)
                CountDown();
        }
                 
    }

    void StartCount()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _startCountdown = true;
        }
    }
    void CountDown()
    {
        

        if (_countDownAmount >= 1)
        {
            _countDownAmount -= 1 * Time.deltaTime;

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
