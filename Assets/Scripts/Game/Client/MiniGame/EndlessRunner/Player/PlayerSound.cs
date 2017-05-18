using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerSound : NetworkBehaviour
{
    [SerializeField] private PlayerStates _playerStatesScript;
    [SerializeField] private PlayerJump _playerJumpScript;

	
    [SerializeField] private AudioSource _playerJumpSound;
    [SerializeField] private AudioSource _playerDeathSound;

    void Awake()
    {
        CheckIsLocal();
    }

    void Start()
    {
        _playerJumpScript.OnPlayerJump += () => _playerJumpSound.Play();
        _playerStatesScript.OnPlayerDeath += () => _playerDeathSound.Play();
    }

    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }
}
