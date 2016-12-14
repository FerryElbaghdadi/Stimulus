using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;

public class RemoveHostText : NetworkBehaviour
{
    [SyncVar(hook = "ChangeTextToRunningGame")]
    private string _newText;


    [SerializeField] private GameStates _gameStatesScript;

    [SerializeField] private Text _studentAmountText;
    [SerializeField] private Text _waitingText;
    [SerializeField] private Text _readyToGoText;

    void Update()
    {
        if (_gameStatesScript.GetGameStartBool)
        {
            _newText = HostTextStrings.empty;
            ChangeTextToRunningGame(_newText);
        }

    }

    private void ChangeTextToRunningGame(string newValue)
    {
        _readyToGoText.text = newValue;
        _studentAmountText.text = newValue;
        _waitingText.text = newValue;
    }

}
