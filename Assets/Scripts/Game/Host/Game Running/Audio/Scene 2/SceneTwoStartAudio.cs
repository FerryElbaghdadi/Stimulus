using UnityEngine;
using System.Collections;

public class SceneTwoStartAudio : MonoBehaviour
{

    [SerializeField] private FadeToSceneTwo _fadeToSceneTwoScript;
    [SerializeField] private AudioSource[] _soundsStart;

    void Start()
    {
        _fadeToSceneTwoScript.OnFadeOut += () =>
        {
            foreach (AudioSource audio in _soundsStart)
                audio.Play();
        };
    }
}
