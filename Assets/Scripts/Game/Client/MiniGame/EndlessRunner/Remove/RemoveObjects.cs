using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class RemoveObjects : NetworkBehaviour
{
    [SerializeField] private MiniGameCountdown _miniGameCountdownScript;
    [SerializeField] private GameObject[] _disabledObjects;

    private bool _runOnce;

    void Start()
    {
        _miniGameCountdownScript.OnMiniGameCountEnd += CmdAddDelegate;
    }

    [Command]
    void CmdAddDelegate()
    {
        RpcRemoveMiniGameObjects();
    }

    [ClientRpc]
    void RpcRemoveMiniGameObjects()
    {
        _runOnce = false;

        if (!_runOnce)
        {
            foreach (GameObject disable in _disabledObjects)
                disable.SetActive(false);
        }

        _runOnce = true;
    }
}
