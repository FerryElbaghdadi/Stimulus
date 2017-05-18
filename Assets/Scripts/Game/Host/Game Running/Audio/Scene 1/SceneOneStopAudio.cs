using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class SceneOneStopAudio : NetworkBehaviour
{

    [SerializeField] private FadeToSceneTwo _fadeToSceneTwoScript;
    [SerializeField] private AudioSource[] _sceneOneSounds;

    [SerializeField] private float _timeMultiplier = 0.05f;
    [SerializeField] private float _minAudio = 0f;

    private bool _deafenMusic;

    void Start()
    {
        _fadeToSceneTwoScript.OnFadeIn += CmdDeafenCommand;
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
            foreach (AudioSource audio in _sceneOneSounds)
            {
                if (audio.volume >= _minAudio)
                {
                    audio.volume -= _timeMultiplier;
                }
                else
                    _deafenMusic = false;
            }
           
        }

    }
}
