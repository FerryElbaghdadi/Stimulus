using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class TouristActivate : NetworkBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;
    [SerializeField] private GameObject _touristObject;

    void Start()
    {
        _gameStatesScript.OnMiniGameOneEnd += () => _touristObject.SetActive(true);
    }
}
