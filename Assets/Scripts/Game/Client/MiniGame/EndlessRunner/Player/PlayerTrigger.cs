using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerTrigger : NetworkBehaviour
{
    /*
     * RESPONSIBILITY: Send a delegate whenever the player has died or not.
     * DEPENDS ON: ClientMiniGameStrings.cs
     */

    public delegate void PlayerTriggerEventHandler();
    public PlayerTriggerEventHandler OnPlayerObstacle;

    void Awake()
    {
        CheckIsLocal();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(ClientMiniGameStrings.obstacle) || coll.CompareTag(ClientMiniGameStrings.stoneobstacle))
        {
            CmdSendDelegate();
        }
    }

    void CmdSendDelegate()
    {
        if (OnPlayerObstacle != null)
            OnPlayerObstacle();
    }

    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }
}
