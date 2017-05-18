using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerJump : NetworkBehaviour
{
    public delegate void PlayerJumpEventHandler();
    public PlayerJumpEventHandler OnPlayerJump;

    [SerializeField] private Rigidbody2D _thisRigidBody2D;

    private float _playerJumpX;
    [SerializeField] private float _playerJumpY = 5f;

    private Vector2 _playerJumpVector;

    [SyncVar]
    private bool _ableToJump = true;

    public bool GetSetAbleToJump
    {
        get { return _ableToJump; }
        set { _ableToJump = value; }
    }


    void Awake()
    {
        CheckIsLocal();
    }

    void Start()
    {
        _playerJumpVector = new Vector2(_playerJumpX, _playerJumpY);
    }

    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (_ableToJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _thisRigidBody2D.velocity = _playerJumpVector;

                if (OnPlayerJump != null)
                    OnPlayerJump();
            }
        }
    }

    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }
}
