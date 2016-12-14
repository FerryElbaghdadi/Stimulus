using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class StartGame : NetworkBehaviour
{
    public delegate void StartGameEventHandler();
    public StartGameEventHandler OnGameStart;


    void Start()
    {
       CheckIsLocal();
    }

    void Update()
    {
 
            if (Input.GetKeyDown(KeyCode.Space))
            {
            if (OnGameStart != null)
                OnGameStart();
            }

    }


    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }
}
