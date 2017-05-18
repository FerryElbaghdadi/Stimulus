using UnityEngine;
using System.Collections;

public class CameraShakeMiniGameThree : MonoBehaviour
{

    [SerializeField]
    private TriggerMiniGameThree _triggerMiniGameThreeScript;
    [SerializeField]
    private CameraShake _cameraShakeScript;

    [SerializeField]
    private float _shakeLength = 3.5f;

    void Start()
    {
        _triggerMiniGameThreeScript.OnTriggerBaby += () => _cameraShakeScript.Shake(_shakeLength);
    }
}
