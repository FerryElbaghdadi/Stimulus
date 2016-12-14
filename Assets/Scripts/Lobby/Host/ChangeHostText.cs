using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

/*
 * RESPONSIBILITY: Change host lobby text whenever a single student joins.
 * 
 * This class is needed to hide the neccessary text whenever
 * a student joins our server.
 * 
 * NOTE: UPDATE IS NEEDED AS OF NOW. DELEGATES WILL BE USED.
 */

public class ChangeHostText : MonoBehaviour
{

	[SerializeField] private AddStudent _addStudentScript;

    [SerializeField] private Text _hostPleaseWaitText;
    [SerializeField] private Text _waitingText;

    private int _studentsNeededToStart = 1;


    void Update()
    {
        ChangeToReadyText();
    }

    void ChangeToReadyText()
    {
        if (_addStudentScript.GetStudents >= _studentsNeededToStart)
        {
            _hostPleaseWaitText.text = HostLobbyStrings.readytogo;
            _waitingText.text = "";
        }
    }
}
