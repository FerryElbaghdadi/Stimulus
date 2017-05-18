using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class MiniGameCounterText : NetworkBehaviour
{
    [SerializeField] private MiniGameCountdown _miniGameCountDownScript;
    
    [SerializeField] private Text _miniGameCountDownText;

	void Start()
    {
        _miniGameCountDownScript.OnMiniGameSecond += CmdCountMiniGameText;
        _miniGameCountDownScript.OnMiniGameCountEnd += CmdEmptyMiniGameText;
    }

    [Command]
    void CmdCountMiniGameText()
    {
        RpcUpdateCounterForClient();
    }

    [Command]
    void CmdEmptyMiniGameText()
    {
        RpcEmptyCounterForClient();
    }

    [ClientRpc]
    void RpcUpdateCounterForClient()
    {
        _miniGameCountDownText.text = _miniGameCountDownScript.GetMiniGameCountDown.ToString("F0");
    }

    [ClientRpc]
    void RpcEmptyCounterForClient()
    {
        _miniGameCountDownText.text = ClientTextStrings.empty;
    }
}
