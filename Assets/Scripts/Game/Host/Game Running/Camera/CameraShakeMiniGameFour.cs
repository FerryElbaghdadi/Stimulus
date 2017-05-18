using UnityEngine;
using System.Collections;

public class CameraShakeMiniGameFour : MonoBehaviour
{

    [SerializeField]
    private TriggerMiniGameFour _triggerMiniGameFourScript;
    [SerializeField]
    private CameraShake _cameraShakeScript;

    [SerializeField]
    private float _shakeLength = 15f;

    void Start()
    {
        _triggerMiniGameFourScript.OnTriggerScanner += () => _cameraShakeScript.Shake(_shakeLength);
    }
}
