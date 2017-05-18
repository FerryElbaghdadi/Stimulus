using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerCollision : NetworkBehaviour
{
    /*
     * RESPONSIBILITY: Send a delegate whenever the player is grounded, or not.
     * DEPENDS ON: ClientMiniGameStrings.cs
     */

    public delegate void PlayerCollisionEventHandler();
    public PlayerCollisionEventHandler OnPlayerGrounded;
    public PlayerCollisionEventHandler OnPlayerAir;

    void Awake()
    {
        CheckIsLocal();
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag(ClientMiniGameStrings.platform))
        {
            if (OnPlayerGrounded != null)
                OnPlayerGrounded();
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.collider.CompareTag(ClientMiniGameStrings.platform))
        {
            if (OnPlayerAir != null)
                OnPlayerAir();
        }
    }

   

    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }
}
