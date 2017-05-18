using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerAnimations : NetworkBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;
    [SerializeField] private PlayerStates _playerStatesScript;

    [SerializeField] private int _rollSpeed = 10;

    [SerializeField] private SpriteRenderer _playerSpriteRenderer;
    [SerializeField] private Color _playerNeutralColour;
    [SerializeField] private Color _playerDeathColour;

    void Start()
    {
        _gameStatesScript.OnMiniGameOneStarted += PlayerWalkAnimation;
        _playerStatesScript.OnPlayerDeath += PlayerDeathAnimation;
    }

    void Update()
    {
        RotateObject();
    }

    void RotateObject()
    {
        this.transform.Rotate(Vector3.back, _rollSpeed);
    }

    void PlayerWalkAnimation()
    {
        _playerSpriteRenderer.color = _playerNeutralColour;
    }

    void PlayerDeathAnimation()
    {
        _playerSpriteRenderer.color = _playerDeathColour;
    }
}
