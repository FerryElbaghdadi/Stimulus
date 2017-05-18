using UnityEngine;
using System.Collections;

public class DisableSceneOneAssets : MonoBehaviour
{
    [SerializeField] private GameStates _gamestatesScript;

    [SerializeField] private GameObject _sceneOneObject;

    void Start()
    {
        _gamestatesScript.OnSceneOneEnd += () => _sceneOneObject.SetActive(false);
    }
}
