using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{

    public Text scoreText;
    public AnimationUi2D scoreAnim;

    public Image backButtonBackground;
    public AnimationUi2D backButtonAnim;
    public Image replayButtonBackground;
    public AnimationUi2D replayButtonAnim;

    public AnimationUi2D panelAnim;

    public GameObject raycastBlocker;

    public void Show()
    {
        ScoreManager.instance.scoreText.gameObject.SetActive(false);
        raycastBlocker.SetActive(true);

        gameObject.SetActive(true);
        StartCoroutine(show());
    }

    public IEnumerator show()
    {

        panelAnim.ZoomIn2d();
        SoundManager.instance.PlaySound(4);

        yield return new WaitForSeconds(2);
        scoreText.text = ScoreManager.instance.score.ToString();
        scoreAnim.ZoomIn2d();

        yield return new WaitForSeconds(1);
        backButtonBackground.enabled = true;
        backButtonAnim.ZoomIn2d();
        replayButtonBackground.enabled = true;
        replayButtonAnim.ZoomIn2d();
    }
}
