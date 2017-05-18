using UnityEngine;
using System.Collections;

public class CameraShakeMiniGameOne : MonoBehaviour
{

    [SerializeField] private TriggerMiniGameOne _triggerMiniGameOneScript;
    [SerializeField] private CameraShake _cameraShakeScript;
    
    [SerializeField] private float _shakeLength = 3.5f;

    void Start()
    {
        _triggerMiniGameOneScript.OnTriggerTram += () => _cameraShakeScript.Shake(_shakeLength);
    }
}
