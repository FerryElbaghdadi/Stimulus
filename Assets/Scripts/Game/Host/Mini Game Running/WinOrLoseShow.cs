using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class WinOrLoseShow : NetworkBehaviour
{
    [SerializeField] private MiniGameWinLoseCheck _miniGameWinLoseCheckScript;

    [SerializeField] private Image _markImage;
    [SerializeField] private Sprite[] _markSprites;

    /*
     * 0 = Check
     * 1 = Cross
     * 2 = Empty
     */

    void Start()
    {
        _miniGameWinLoseCheckScript.OnPlayerWin += ShowCheckMark;
        _miniGameWinLoseCheckScript.OnPlayerLose += ShowCrossMark;
    }

    void ShowCheckMark()
    {
        StartCoroutine(TemporaryMark(_markSprites[0]));
    }

    void ShowCrossMark()
    {
        StartCoroutine(TemporaryMark(_markSprites[1]));
    }

    private IEnumerator TemporaryMark(Sprite mark)
    {
        yield return new WaitForSeconds(3);
        _markImage.sprite = mark;
        yield return new WaitForSeconds(2);
        _markImage.sprite = _markSprites[2];
    }
}
