using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;


public class ClientText : NetworkBehaviour
{
    [SyncVar(hook = "ChangeTextToRunningGame")]
    private string _newText;


    [SerializeField] private GameStates _gameStatesScript;

    [SerializeField] private Text _placeholderText;

    void Start()
    {
        _gameStatesScript.OnGameStarted += StartGameText;
        _gameStatesScript.OnMiniGameStarted += StartMiniGameText;
        _gameStatesScript.OnMiniGameEnd += WatchDigiBoardText;
    }

   void StartGameText()
    {
            _newText = ClientTextStrings.runninggame;
            ChangeTextToRunningGame(_newText);
    }

    void StartMiniGameText()
    {
        _newText = ClientTextStrings.runningminigame;
        ChangeTextToRunningGame(_newText);
    }

    void WatchDigiBoardText()
    {
        _newText = ClientTextStrings.runninggame;
        ChangeTextToRunningGame(_newText);
    }

   private void ChangeTextToRunningGame(string newValue)
    {
        _placeholderText.text = newValue;
    }

}
