using UnityEngine;
using System.Collections;

public class DontDestroyMenuMusic : MonoBehaviour
{
        void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
