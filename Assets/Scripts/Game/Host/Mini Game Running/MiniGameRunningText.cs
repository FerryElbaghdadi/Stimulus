using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class MiniGameRunningText : NetworkBehaviour
{
    [SerializeField] private Text _runningMiniGameText;
    [SerializeField] private Text _pleaseCheckDeviceText;
    [SerializeField] private GameStates _gameStatesScript;

   [SyncVar] private bool _runOnce;

    void Start()
    {
        _gameStatesScript.OnMiniGameStarted += ChangeToRunning;
    }

    void ChangeToRunning()
    {

        if (!_runOnce)
        {
            _runningMiniGameText.text = HostTextStrings.runningminigame;
            _pleaseCheckDeviceText.text = HostTextStrings.pleasecheckyourdevice;

        }

        _runOnce = true;
    }
}
