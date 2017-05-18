using UnityEngine;
using System.Collections;

public class ActivateFinalScene : MonoBehaviour
{
    [SerializeField] private GameStates _gamestatesScript;
    [SerializeField] private StressMeterAmount _stressMeterAmount;

    [SerializeField] private GameObject _winObject;
    [SerializeField] private GameObject _loseObject;

    void Start()
    {
        _gamestatesScript.OnSceneThreeEnd += CheckCondition;
    }

    void CheckCondition()
    {
        if (_stressMeterAmount.GetCurrentFillAmount > 0)
            _winObject.SetActive(true);
        else
            _loseObject.SetActive(true);
    }
}
