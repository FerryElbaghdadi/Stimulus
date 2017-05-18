using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MiniGameStateHandler : NetworkBehaviour
{
    [SyncVar] private bool _clearedGameTrue;
    [SyncVar] private bool _clearedGameFalse;
    [SyncVar] private bool _neutralGameState;

    [SyncVar] private float _amountOfCleared;
    [SyncVar] private float _amountOfLost;

    public bool GetClearedGameTrue
    {
        get { return _clearedGameTrue; }
        set { _clearedGameTrue = value; }
    }

    public bool GetClearedGameFalse
    {
        get { return _clearedGameFalse; }
        set { _clearedGameFalse = value; }
    }

}
