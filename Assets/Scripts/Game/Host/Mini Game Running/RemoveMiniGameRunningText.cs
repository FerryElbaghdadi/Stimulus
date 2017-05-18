using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

/*
 * RESPONSIBILITY: Empty the running game texts.
 */

public class RemoveMiniGameRunningText : NetworkBehaviour
{
    [SerializeField] private MiniGameCountdown _miniGameCountdownScript;
    [SerializeField] private Text[] _runningMiniGameTexts;

    private bool _runOnce;

    void Start()
    {
        _miniGameCountdownScript.OnMiniGameCountEnd += () =>
        {
            if (!_runOnce)
            {
                foreach (Text runningminigametext in _runningMiniGameTexts) runningminigametext.text = HostTextStrings.empty;
            }

            _runOnce = true;
        };
        }

}
