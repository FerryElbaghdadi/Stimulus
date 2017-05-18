using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DeafenMenuMusic : NetworkBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;
    private AudioSource _mainMenuMusic;
    

   [SerializeField] private float _timeMultiplier = 0.05f;
    [SerializeField] private float _minAudio = 0f;

    private bool _deafenMusic;

    void Start()
    {
        _mainMenuMusic = GameObject.Find(AudioStrings.mainmenumusic).GetComponent<AudioSource>();
        _gameStatesScript.OnGameStarted += CmdDeafenCommand;
    }

    void Update()
    {
        CheckCanDeafen();
    }

    [Command]
    void CmdDeafenCommand()
    {
        _deafenMusic = true;
        
    }

    void CheckCanDeafen()
    {
        if (_deafenMusic)
        {
            if (_mainMenuMusic.volume >= _minAudio)
            {
                _mainMenuMusic.volume -= _timeMultiplier;
            }
            else
                _deafenMusic = false;
        }
        
    }
}
