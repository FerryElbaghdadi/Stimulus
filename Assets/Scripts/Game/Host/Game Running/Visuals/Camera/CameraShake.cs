using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _shakePower = 0f;
    [SerializeField] private float _shakePowerMin = 0f;
    [SerializeField] private float _shakePowerMax = 0.015f;

    public float SetShakePower
    {
        get { return _shakePower; }
        set { _shakePower = value; }
    }

    /*
     * Using a getter and setter for adjusting the shake's power.
     * We'll be using this in other scripts.
     */

    private bool _isShaking;

    [SerializeField] private Camera _gameCamera;
    [SerializeField] private Vector3 _startPos;
    
	void Update () 
    {
        ShakeCamera();
	}

    private void ShakeCamera()
    {
        if (_shakePower <= _shakePowerMax)
            _shakePower += 0.001f * Time.deltaTime;

        if (_isShaking)
        {
            _gameCamera.orthographicSize = 4.5f;
            transform.localPosition = transform.localPosition + Random.insideUnitSphere * _shakePower;
        }
        else
        {
            if (_shakePower >= _shakePowerMin)
                _shakePower -= 0.001f * Time.deltaTime;

            _gameCamera.orthographicSize = 5f;
        }
            
    }


    public void Shake(float duration)
    {
        _isShaking = true;
        CancelInvoke();
        Invoke("StopShaking", duration);
    }

    /*
     * Start shaking.
     */
 

    public void StopShaking()
    {
        _isShaking = false;
        this.transform.position = _startPos;
    }

    /*
     * Gets called after the shake gets triggered.
     */ 
}
