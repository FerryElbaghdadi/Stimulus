using UnityEngine;
using System.Collections;

public class BrainExpressions : MonoBehaviour
{
    /*
     * This is the script that 'stores' the facial expressions
     * of the brain. All functions are public so that they could
     * be accessed in the 'ChangeBrainExpression' script.
     * 
     * RESPONSIBILITY: Hold the facial expressions of the brain,
     * ready to be used whenever in a function.
     */


    [SerializeField] private SpriteRenderer[] _brainSpriteRenderers;

    /*
     * 0 = Left Brain
     * 1 = Right Brain
     */
    [SerializeField] private Sprite[] _spriteExpressions;

    /*
     * 0 = Happy
     * 1 = Worried
     * 2 = Stressed
     * 3 = Sad / Game Over
     */

    public void Happy()
    {
        foreach (SpriteRenderer brain in _brainSpriteRenderers)
            brain.sprite = _spriteExpressions[0];
    }

    public void Worried()
    {
        foreach (SpriteRenderer brain in _brainSpriteRenderers)
            brain.sprite = _spriteExpressions[1];
    }

    public void Stressed()
    {
        foreach (SpriteRenderer brain in _brainSpriteRenderers)
            brain.sprite = _spriteExpressions[2];
    }

    public void Sad()
    {
        foreach (SpriteRenderer brain in _brainSpriteRenderers)
            brain.sprite = _spriteExpressions[3];
    }
}
