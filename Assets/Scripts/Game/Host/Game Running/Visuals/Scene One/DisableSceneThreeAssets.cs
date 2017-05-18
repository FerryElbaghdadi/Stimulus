using UnityEngine;
using System.Collections;

public class DisableSceneThreeAssets : MonoBehaviour
{
    [SerializeField] private GameStates _gamestatesScript;

    [SerializeField] private GameObject _sceneThreeObject;

    void Start()
    {
        _gamestatesScript.OnSceneThreeEnd += () => _sceneThreeObject.SetActive(false);
    }
}
