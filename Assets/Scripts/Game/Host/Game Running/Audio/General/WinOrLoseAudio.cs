using UnityEngine;
using System.Collections;

public class WinOrLoseAudio : MonoBehaviour
{

    [SerializeField] private AudioSource _correctSound;
     [SerializeField] private AudioSource _wrongSound;
	
    [SerializeField] private MiniGameWinLoseCheck _miniScript;

    private float _amountOfSeconds = 2.25f;

    void Start()
    {
        _miniScript.OnPlayerWin += () => StartCoroutine(WaitForSound(true));
        _miniScript.OnPlayerLose += () => StartCoroutine(WaitForSound(false));

    }

    IEnumerator WaitForSound(bool win)
    {
        yield return new WaitForSeconds(_amountOfSeconds);
        if(win) _correctSound.Play();
        else _wrongSound.Play();
    }
}
