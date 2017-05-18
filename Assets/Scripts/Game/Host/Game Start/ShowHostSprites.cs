using UnityEngine;
using System.Collections;

public class ShowHostSprites : MonoBehaviour
{
    [SerializeField] private StartGame _startGameScript;
    [SerializeField] private GameObject[] _brainSprites;
    [SerializeField] private GameObject _controlPanelSprite;
    [SerializeField] private GameObject _digiboardSprite;
    [SerializeField] private GameObject[] _environmentSprites;

    void Start()
    {
        _startGameScript.OnGameStart += () => { foreach (GameObject brain in _brainSprites) brain.SetActive(true); };
        _startGameScript.OnGameStart += () => { foreach (GameObject prop in _environmentSprites) prop.SetActive(true); };
        _startGameScript.OnGameStart += () => _controlPanelSprite.SetActive(true);
        _startGameScript.OnGameStart += () => _digiboardSprite.SetActive(true);
    }
}
