using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ActivateLoadingScreen : MonoBehaviour
{
    [SerializeField] private CustomNetworkManagerHUD _networkManagerScript;
    [SerializeField] private GameObject _loadingImage;

    void Start()
    {
        _networkManagerScript.OnClientConnecting += () => _loadingImage.SetActive(true);
        _networkManagerScript.OnClientConnect += () => _loadingImage.SetActive(false);
    }
}
