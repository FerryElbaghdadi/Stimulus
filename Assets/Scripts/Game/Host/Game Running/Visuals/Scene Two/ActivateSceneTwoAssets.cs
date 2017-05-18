using UnityEngine;
using System.Collections;

public class ActivateSceneTwoAssets : MonoBehaviour
{
    [SerializeField] private GameStates _gamestatesScript;

    [SerializeField] private GameObject _sceneTwoObject;

    void Start()
    {
        _gamestatesScript.OnSceneOneEnd += () => _sceneTwoObject.SetActive(true);
    }
}
