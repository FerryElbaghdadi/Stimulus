using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TriggerMiniGameTwo : NetworkBehaviour
{
    public delegate void MiniGameTwoEventHandler();
    public MiniGameTwoEventHandler OnTriggerTourists;
    public MiniGameTwoEventHandler OnTriggerFlash;

    private float _secondsUntilMiniGame = 6f;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag(ClientMiniGameStrings.platform))
        {
            StartCoroutine("StartMiniGameTwo");

            if (OnTriggerFlash != null)
                OnTriggerFlash();
        }
    }

    private IEnumerator StartMiniGameTwo()
    {
        yield return new WaitForSeconds(_secondsUntilMiniGame);

        if (OnTriggerTourists != null)
            OnTriggerTourists();
    }
}
