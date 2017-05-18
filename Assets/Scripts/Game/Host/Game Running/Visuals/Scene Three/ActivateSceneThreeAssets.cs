using UnityEngine;
using System.Collections;

public class ActivateSceneThreeAssets : MonoBehaviour
{
    [SerializeField] private GameStates _gamestatesScript;

    [SerializeField] private GameObject _sceneThreeObject;

    void Start()
    {
        _gamestatesScript.OnSceneTwoEnd += () => _sceneThreeObject.SetActive(true);
    }
}
