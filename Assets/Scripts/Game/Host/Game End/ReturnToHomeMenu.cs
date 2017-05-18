using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class ReturnToHomeMenu : MonoBehaviour
{
    [SerializeField] private NetworkManager _networkManagerScript;
    
    [SerializeField] private float _amountOfSecondsUntilReturn = 5f;

    void Start()
    {
        _networkManagerScript = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        StartCoroutine("ReturnToMenu");
    }

    IEnumerator ReturnToMenu()
    {
        yield return new WaitForSeconds(_amountOfSecondsUntilReturn);
        _networkManagerScript.StopHost();
    }

}
