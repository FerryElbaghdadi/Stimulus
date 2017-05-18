using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TriggerMiniGameThree : NetworkBehaviour
{
    public delegate void MiniGameThreeEventHandler();
    public MiniGameThreeEventHandler OnTriggerBaby;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Box"))
        {
            if (OnTriggerBaby != null)
                OnTriggerBaby();
        }
    }
}
