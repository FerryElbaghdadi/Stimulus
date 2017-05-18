using UnityEngine;
using System.Collections;

public class SceneOneTriggerMiniGameTwoAudio : MonoBehaviour
{
    [SerializeField] private TriggerMiniGameTwo _triggerScript;
    [SerializeField] private AudioSource _triggerAudio;

    void Start()
    {
        _triggerScript.OnTriggerFlash += () => _triggerAudio.Play();
    }
}
