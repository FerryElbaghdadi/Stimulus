using UnityEngine;
using System.Collections;

public class ShowHostUI : MonoBehaviour
{
    [SerializeField] private StartGame _startGameScript;
    [SerializeField] private GameObject _stressMeter;
	
    void Start()
    {
        _startGameScript.OnGameStart += ShowUserInterface;
    }

    void ShowUserInterface()
    {
        _stressMeter.SetActive(true);
    }
}
