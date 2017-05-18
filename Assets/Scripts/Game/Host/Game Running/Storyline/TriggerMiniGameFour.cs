using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TriggerMiniGameFour : NetworkBehaviour
{
    public delegate void MiniGameOneEventHandler();
    public MiniGameOneEventHandler OnTriggerScanner;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("FinalFruit"))
        {
            if (OnTriggerScanner != null)
                OnTriggerScanner();
        }
    }
}
