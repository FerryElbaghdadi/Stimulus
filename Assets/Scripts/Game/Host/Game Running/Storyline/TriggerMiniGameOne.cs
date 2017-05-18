using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TriggerMiniGameOne : NetworkBehaviour
{
    public delegate void MiniGameOneEventHandler();
    public MiniGameOneEventHandler OnTriggerTram;

	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Tram"))
        {
            if (OnTriggerTram != null)
                OnTriggerTram();
        }
    }
}
