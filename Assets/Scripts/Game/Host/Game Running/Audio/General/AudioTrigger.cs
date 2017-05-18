using UnityEngine;
using System.Collections;

public class AudioTrigger : MonoBehaviour
{
    
    [SerializeField] private AudioSource _audioToPlay;
    [SerializeField] private AudioSource _specificAudio;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag(EnvironmentStrings.audiocompatible) || coll.CompareTag(EnvironmentStrings.fruit))
            _audioToPlay.Play();

        else if (coll.CompareTag(EnvironmentStrings.lastfruit))
            _specificAudio.Play();
    }
  
}
