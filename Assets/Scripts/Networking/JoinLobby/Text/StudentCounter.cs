using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;


namespace UnityEngine.Networking
{ 
public class StudentCounter : NetworkBehaviour
{
       //GameObject
        [SerializeField]
        private CustomNetworkManagerHUD _customNetworkManagerScript;
        //GameObject

        //Int
        [SerializeField]
        private int students; // The round that the game will play in.
        private int one = 1; // This is the value we will be using to change the rounds.
        //Int

        public int GetStudents
        {
            get { return students; }
        }

        [SerializeField]
        private bool _useThisScript;


        public delegate void StudentCounterEventHandler();
        public StudentCounterEventHandler OnLoadResource;
        public StudentCounterEventHandler OnSaveResource;

        void CheckIsLocal()
        {
            if (!isLocalPlayer)
                return;
        }


        void Start()
    {

            CheckIsLocal();

      if (_useThisScript)
            {
                if (_customNetworkManagerScript != null)
                    _customNetworkManagerScript.OnClientConnect += AddStudent;
                else
                {
                    print("In-game. Loading students . . . ");
                    LoadResource();

                }
            }
               
            
           
        }


      private void AddStudent()
        {
            students += one;
            SaveResource();
        }
    
 
    public void SaveResource()
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath + "/AmountOf.students");

        SaveData saveData = new SaveData();
        saveData.students = students;
        bf.Serialize(file, saveData);

        file.Close();

            if (OnSaveResource != null)
                OnSaveResource();
    }

    public void LoadResource()
    {
        BinaryFormatter bf = new BinaryFormatter();

        if (File.Exists(Application.persistentDataPath + "/AmountOf.students"))
        {
            FileStream file = File.Open(Application.persistentDataPath + "/AmountOf.students", FileMode.Open);

            SaveData saveData = (SaveData)bf.Deserialize(file);

            students = saveData.students;

            file.Close();
        }

        else
            print("Eat your spaghetti every-day-a!");

            if (OnLoadResource != null)
                OnLoadResource();
    }


    [System.Serializable]
    public class SaveData
    {
        public int students;
    }
}
}