using UnityEngine;
using System.Collections;

public class HumanMovement : MonoBehaviour
{

    [SerializeField] private float _movementSpeed;
    [SerializeField] private Rigidbody2D _playerRigidBody2D;
    [SerializeField] private Vector2 _playerVector2;

    void Start()
    {
        _playerVector2 = new Vector2(_movementSpeed, 0);
        _playerRigidBody2D.velocity = _playerVector2;
    }
}
