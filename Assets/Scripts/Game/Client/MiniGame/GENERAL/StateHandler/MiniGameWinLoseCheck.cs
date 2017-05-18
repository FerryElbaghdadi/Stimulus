using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MiniGameWinLoseCheck : NetworkBehaviour
{

   [SerializeField] private MiniGameStates _miniGameStatesScript;
   [SerializeField] private MiniGameCountdown _miniGameCountdownScript;
   [SerializeField] private StudentAmount _studentAmountScript;
   [SerializeField] private AmountOfDeaths _amountOfDeathsScript;
   
    public delegate void WinLoseCheckEventHandler();
    public WinLoseCheckEventHandler OnPlayerLose;
    public WinLoseCheckEventHandler OnPlayerWin;

    [SerializeField] private int _halfStudents = 2;

   void Start()
    {
        _miniGameCountdownScript.OnMiniGameCountEnd += CheckIfLost;
    }

    void CheckIfLost()
    {

        //  if (_studentAmountScript.GetStudents / _halfStudents <= _amountOfDeathsScript.GetPlayerDeaths)
        if (_studentAmountScript.GetStudents >= _amountOfDeathsScript.GetPlayerDeaths)
        {
                if (OnPlayerLose != null)
                    OnPlayerLose();
            }
            else
            {
                if (OnPlayerWin != null)
                    OnPlayerWin();
            }
    }

}
