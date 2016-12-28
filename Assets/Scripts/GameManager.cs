using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int life = 3;
    public bool isGameOver = false;
    public AnimationUi2D vinetteMask;
    public GameObject tapToPlay;
    public GameOverPanel gameOverPanel;
    public static GameManager instance;

    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        if (tapToPlay != null)
            tapToPlay.SetActive(true);
    }

    public void ShowMask()
    {
        vinetteMask.FadeIn();
    }

    public void HideMask()
    {
        vinetteMask.FadeOut();
    }

    public void GameOver()
    {
        StartCoroutine(gameOver());
    }

    public IEnumerator gameOver()
    {
        if (isGameOver == false)
        {
            isGameOver = true;
            BubblePooling.instance.StopAllCoroutines();
            SoundManager.instance.FadeOutBgm(2);
            ShowMask();
            yield return new WaitForSeconds(2);
            gameOverPanel.Show();
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("01");
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SubtractLife(int amount)
    {
        life -= amount;
        if (life <= 0)
            GameOver();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        Time.timeScale = 1;
    }
}
