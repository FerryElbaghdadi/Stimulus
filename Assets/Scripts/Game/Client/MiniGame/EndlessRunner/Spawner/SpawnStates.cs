using UnityEngine;
using System.Collections;

public class SpawnStates : MonoBehaviour
{
    public delegate void SpawnEventHandler();
    public SpawnEventHandler OnGroundReturnSpawn;
    public SpawnEventHandler OnAirReturnSpawn;

    [SerializeField] private ReturnSpawn _returnSpawnScript;


    void Start()
    {
        _returnSpawnScript.OnGroundSpawnReturn += SendGroundReturnSpawn;
        _returnSpawnScript.OnAirSpawnReturn += SendAirReturnSpawn;
    }

    void SendGroundReturnSpawn()
    {
        if (OnGroundReturnSpawn != null)
            OnGroundReturnSpawn();
    }

    void SendAirReturnSpawn()
    {
        if (OnAirReturnSpawn != null)
            OnAirReturnSpawn();
    }
}
