using UnityEngine;
using System.Collections;


/*
 * This script takes care of changing the expression
 * of the brains throughout the game.
 * 
 * RESPONSIBILITY: Change the expression of the brains on certain events.
 */

public class ChangeBrainExpression : MonoBehaviour
{

    [SerializeField] private BrainExpressions _brainExpressionsScript;
    [SerializeField] private StressMeterAmount _stressMeterAmountScript;

    private float _happyExpressionValue = 1f;
    private float _worriedExpressionValue = 0.75f;
    private float _stressedExpressionValue = 0.5f;
    private float _sadExpressionValue = 0f;

    void Start()
    {
        _stressMeterAmountScript.OnMeterChange += ChangeExpression; // Function gets called once delegate happens.
    }

    void ChangeExpression()
    {
        if (_stressMeterAmountScript.GetCurrentFillAmount == _happyExpressionValue)
            _brainExpressionsScript.Happy();

        else if (_stressMeterAmountScript.GetCurrentFillAmount == _worriedExpressionValue)
            _brainExpressionsScript.Worried();

        else if (_stressMeterAmountScript.GetCurrentFillAmount == _stressedExpressionValue)
            _brainExpressionsScript.Stressed();

        else if (_stressMeterAmountScript.GetCurrentFillAmount == _sadExpressionValue)
            _brainExpressionsScript.Sad();

        /*
         * Once the FillAmount of our stress meter image has reached a certain value,
         * a certain function will get called to change the facial expression of the brain.
         */
    }

}
