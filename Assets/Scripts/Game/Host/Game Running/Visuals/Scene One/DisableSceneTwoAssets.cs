using UnityEngine;
using System.Collections;

public class DisableSceneTwoAssets : MonoBehaviour
{
    [SerializeField] private GameStates _gamestatesScript;

    [SerializeField] private GameObject _sceneTwoObject;

    void Start()
    {
        _gamestatesScript.OnSceneTwoEnd += () => _sceneTwoObject.SetActive(false);
    }
}
