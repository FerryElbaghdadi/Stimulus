using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class StartGame : NetworkBehaviour
{

    [SerializeField] private StudentAmount _studentAmountScript;
    [SerializeField] private FadeToGame _fadeToGameScript;

    private int _studentsNeededToStart = 1;

    public delegate void StartGameEventHandler();
    public StartGameEventHandler OnGameEnter;
    public StartGameEventHandler OnGameStart;

    private bool _startedGame;


    void Start()
    {
       CheckIsLocal();

        _fadeToGameScript.OnFadeOut += CmdStartGame;
    }

    void Update()
    {
        CmdEnterGame();
    }

    [Command]
    void CmdEnterGame()
    {
        if (_studentAmountScript.GetStudents >= _studentsNeededToStart)
        {
            if (!_startedGame)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (OnGameEnter != null)
                        OnGameEnter();

                    _startedGame = true;
                }
            }
            
        }
    }

    [Command]
    void CmdStartGame()
    {
        if (OnGameStart != null)
            OnGameStart();
    }


    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }
}
