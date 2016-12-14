using UnityEngine;
using System.Collections;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _thisRigidBody2D;

    private float _playerJumpX;
    [SerializeField] private float _playerJumpY = 5f;
    private Vector2 _playerJumpVector;

    void Start()
    {
        _playerJumpVector = new Vector2(_playerJumpX, _playerJumpY);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _thisRigidBody2D.velocity = _playerJumpVector;
        }
    }
}
