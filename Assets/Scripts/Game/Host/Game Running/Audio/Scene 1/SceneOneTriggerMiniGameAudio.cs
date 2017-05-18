using UnityEngine;
using System.Collections;

public class SceneOneTriggerMiniGameAudio : MonoBehaviour
{
    [SerializeField] private TriggerMiniGameOne _triggerScript;
    [SerializeField] private AudioSource _triggerAudio;

    void Start()
    {
        _triggerScript.OnTriggerTram += () => _triggerAudio.Play();
    }
}
