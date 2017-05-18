using UnityEngine;
using System.Collections;

/*
     * This script handles the fade effect whenever the game starts
     * After all students have joined.
     * 
     * RESPONSIBILITY: Call two animations/functions once a certain delegate taken place.
     */

public class FadeToGame : MonoBehaviour
{

    public delegate void FadeToGameEventHandler();
    public FadeToGameEventHandler OnFadeOut;

    [SerializeField] private StartGame _startGameScript;
    [SerializeField] private Animator[] _blackScreenAnimations;

    private int _fadeCountdown = 3;


    void Start()
    {
        _startGameScript.OnGameEnter += FadeInScreen;
    }

    void FadeInScreen()
    {
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
