using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class AddStudent : NetworkBehaviour
{

    private int _amountOfStudents;

    public int GetStudents
    {
        get { return _amountOfStudents; }
    }

    public delegate void StudentCounterEventHandler();
    public StudentCounterEventHandler OnJoinStudent;

    private NetworkManager _networkManager;

    private bool _studentJoined;

    void Awake()
    {
        _networkManager = GameObject.FindObjectOfType<NetworkManager>();
    }

    void Start()
    {
        /*
        if (_studentJoined)
        {
            _amountOfStudents = (_networkManager.numPlayers) - 1;

            if (OnJoinStudent != null)
                OnJoinStudent();


        }

        _studentJoined = false;
        _studentJoined = true;
        */
    }

    void Update()
    {
        CheckOnAmount();
    }

    void CheckOnAmount()
    {

            _amountOfStudents = (_networkManager.numPlayers) - 1;
         //   print(_amountOfStudents);
    }

    void CheckIsLocal()
    {
        if (!isLocalPlayer)
            return;
    }
}
