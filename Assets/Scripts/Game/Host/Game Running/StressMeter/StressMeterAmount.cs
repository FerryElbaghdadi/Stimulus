using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

/*
 * This script stands for the stress meter of the game.
 * The stress meter changes it's value after a mini-game has been finished.
 * Once the mini game has been finished correctly, either:
 * Nothing will happen, or the meter will get down.
 * If the mini game fails, the meter will get filled.
 * 
 * RESPONSIBILITY: Change the amount of the stress meter when needed.
 */

public class StressMeterAmount : NetworkBehaviour
{

    [SerializeField] private MiniGameWinLoseCheck _miniGameWinLoseCheckScript;
	[SerializeField] private Image _stressMeterImage;

    [SerializeField] private float _maxStressValue = 1f;
    [SerializeField] private float _valueAmountChanger = 0.25f;
    [SerializeField] private float _currentFillAmount;

    public delegate void StressMeterEventHandler();
    public StressMeterEventHandler OnMeterChange;

    public float GetCurrentFillAmount
    {
        get { return _currentFillAmount; }
    }


    void Start()
    {
        _miniGameWinLoseCheckScript.OnPlayerWin += () => AdjustBar(_valueAmountChanger);
        _miniGameWinLoseCheckScript.OnPlayerLose += () => AdjustBar(-_valueAmountChanger);
    }

    void AdjustBar(float amount)
    {
        if (_stressMeterImage.fillAmount <= _maxStressValue)
        _stressMeterImage.fillAmount += amount;

        _currentFillAmount = _stressMeterImage.fillAmount;

        if (OnMeterChange != null)
            OnMeterChange();
    }
}
