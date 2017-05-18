using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ReturnSpawn : NetworkBehaviour
{
    public delegate void ReturnSpawnEventHandler();
    public ReturnSpawnEventHandler OnGroundSpawnReturn;
    public ReturnSpawnEventHandler OnAirSpawnReturn;

    [SerializeField] private Transform[] _stoneTransforms;
    [SerializeField] private Transform[] _airTransforms;

    [SerializeField] private GameObject _groundObject;
    [SerializeField] private GameObject _airObject;

    
	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(ClientMiniGameStrings.stoneobstacle))
        {
            if (OnGroundSpawnReturn != null)
                OnGroundSpawnReturn();

            coll.transform.position = _stoneTransforms[Random.Range(0, 1)].transform.position;
        }

        if (coll.CompareTag(ClientMiniGameStrings.obstacle))
        {
            if (OnAirSpawnReturn != null)
                OnAirSpawnReturn();

          //  coll.gameObject = _airObject;
            coll.transform.position = _airTransforms[Random.Range(0, 1)].transform.position;
        }
    }
}
