using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RunningMiniGame : NetworkBehaviour
{

	[SerializeField] private DigiboardCountdown _digiboardCountdownScript;

    public delegate void RunningMiniGameEventHandler();
    public RunningMiniGameEventHandler OnMiniGameStart;

    void Start()
    {
        _digiboardCountdownScript.OnEndCountdown += () =>
        {
            if (OnMiniGameStart != null)
                OnMiniGameStart();
        };
    }

    
}
