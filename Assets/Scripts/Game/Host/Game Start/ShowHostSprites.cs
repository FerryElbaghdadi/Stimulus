using UnityEngine;
using System.Collections;

public class ShowHostSprites : MonoBehaviour
{
    [SerializeField] private StartGame _startGameScript;
    [SerializeField] private GameObject[] _brainSprites;
    [SerializeField] private GameObject _controlPanelSprite;
    [SerializeField] private GameObject _digiboardSprite;

    void Start()
    {
        _startGameScript.OnGameStart += ShowBrainSprites;
        _startGameScript.OnGameStart += ShowControlPanelSprite;
        _startGameScript.OnGameStart += ShowDigioard;
    }

    void ShowBrainSprites()
    {
        foreach (GameObject brain in _brainSprites)
            brain.SetActive(true);
    }

    void ShowControlPanelSprite()
    {
        _controlPanelSprite.SetActive(true);
    }
    
    void ShowDigioard()
    {
        _digiboardSprite.SetActive(true);
    }
}
