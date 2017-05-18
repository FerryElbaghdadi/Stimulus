using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TramMovement : NetworkBehaviour
{
    [SerializeField] private Rigidbody2D _thisRigidbody2D;

    [SyncVar] [SerializeField] private float _maxTramSpeed;

    [SyncVar] [SerializeField] private Vector2 _tramVector;

    void Awake()
    {
        _tramVector = new Vector2(_maxTramSpeed, 0);
    }

    void Start()
    {
        _thisRigidbody2D.velocity = _tramVector;
    }
}