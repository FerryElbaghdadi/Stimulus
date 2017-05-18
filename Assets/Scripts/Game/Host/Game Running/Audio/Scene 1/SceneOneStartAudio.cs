using UnityEngine;
using System.Collections;

public class SceneOneStartAudio : MonoBehaviour
{

    [SerializeField] private GameStates _gameStatesScript;
    [SerializeField] private AudioSource[] _soundsStart;

    void Start()
    {
        _gameStatesScript.OnGameStarted += () =>
        {
            foreach (AudioSource audio in _soundsStart)
                audio.Play();
        };
    }
}
