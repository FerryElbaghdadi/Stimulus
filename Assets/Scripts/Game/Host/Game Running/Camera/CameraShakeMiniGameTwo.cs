using UnityEngine;
using System.Collections;

public class CameraShakeMiniGameTwo : MonoBehaviour
{

    [SerializeField]
    private TriggerMiniGameTwo _triggerMiniGameTwoScript;
    [SerializeField]
    private CameraShake _cameraShakeScript;

    [SerializeField]
    private float _shakeLength = 3.5f;

    void Start()
    {
        _triggerMiniGameTwoScript.OnTriggerTourists += () => _cameraShakeScript.Shake(_shakeLength);
    }
}
