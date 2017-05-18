using UnityEngine;
using System.Collections;

/*
     * This script handles the fade effect whenever the game ends the second scene.
     * 
     * RESPONSIBILITY: Call two animations/functions once a certain delegate taken place.
     */

public class FadeToFinalScene : MonoBehaviour
{
    [SerializeField] private GameStates _gameStatesScript;

    public delegate void FadeEventHandler();
    public FadeEventHandler OnFadeOut;

    [SerializeField] private Animator[] _blackScreenAnimations;

    private int _fadeInCountdown = 10;
    private int _fadeCountdown = 3;


    void Start()
    {
        _gameStatesScript.OnMiniGameFourEnd += () => StartCoroutine("FadeInScreen");
    }


    IEnumerator FadeInScreen()
    {
        yield return new WaitForSeconds(_fadeInCountdown);

        foreach (Animator blackscreen in _blackScreenAnimations)
        {
            blackscreen.SetBool(AnimationStrings.fadeout, false);
            blackscreen.SetBool(AnimationStrings.fadein, true);
        }

        StartCoroutine("FadingCountdown");

    }

    private IEnumerator FadingCountdown()
    {
        yield return new WaitForSeconds(_fadeCountdown);
        FadeOutScreen();
    }

    void FadeOutScreen()
    {
        foreach (Animator blackscreen in _blackScreenAnimations)
        {
            blackscreen.SetBool("FadeOut", true);
            blackscreen.SetBool("FadeIn", false);
        }

        if (OnFadeOut != null)
            OnFadeOut();
    }
}
