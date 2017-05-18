using UnityEngine;
using System.Collections;

public class MiniGameStates : MonoBehaviour
{

	[SerializeField] private MiniGameCountdown _miniGameCountdownScript;
    [SerializeField] private DigiboardCountdown _digiboardCountdownScript;

    [SerializeField] private bool _runningMiniGame;

    public bool IsRunningGame
    {
        get { return _runningMiniGame; }
    }


    void Start()
    {
        _digiboardCountdownScript.OnEndCountdown += () => _runningMiniGame = true;
        _miniGameCountdownScript.OnMiniGameCountEnd += () => _runningMiniGame = false;
    }

}
