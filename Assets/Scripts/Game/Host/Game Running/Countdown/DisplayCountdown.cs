using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayCountdown : MonoBehaviour
{

    [SerializeField] private DigiboardCountdown _digiboardCountdownScript;

    [SerializeField] private Text _digiboardText;

    void Start()
    {
        _digiboardCountdownScript.OnCountdown += UpdateCountdownText;
        _digiboardCountdownScript.OnEndCountdown += RemoveCountdownText;
    }

    void UpdateCountdownText()
    {
        _digiboardText.text = _digiboardCountdownScript.GetCountDown.ToString("F0");
    }

    void RemoveCountdownText()
    {
        _digiboardText.text = "";
    }

}
