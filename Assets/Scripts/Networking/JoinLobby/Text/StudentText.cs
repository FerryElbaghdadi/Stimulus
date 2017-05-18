using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

/*
 * RESPONSIBILITY: Update the amount of students text whenever it is needed.
 * 
 * This class is needed update the text on the digiboard
 * for whenever a student joins.
 * It showcases the amount of joined students on-screen.
 * 
 * NOTE: UPDATE IS NEEDED AS OF NOW. DELEGATES WILL BE USED.
 */


    public class StudentText : MonoBehaviour
    {
       
        [SerializeField] private GameStates _gameStatesScript;
        [SerializeField] private StudentAmount _amountOfStudentsScript;
        [SerializeField] private Text _numberOfStudentsText;

        void Start()
        {
        //    _amountOfStudentsScript.OnJoinStudent += ChangeText;
        }

        /*

        void ChangeText()
        {
            _numberOfStudentsText.text = "Amount of Students: " + _amountOfStudentsScript.GetStudents;
        }
        */

        void Update()
        {
        
            UpdateStudents();
        }

    void UpdateStudents()
    {
        if (!_gameStatesScript.GetGameStartBool)
            _numberOfStudentsText.text = "Amount of Students: " + _amountOfStudentsScript.GetStudents;
    }
    }
