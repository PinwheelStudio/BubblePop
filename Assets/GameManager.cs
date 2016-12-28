using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public bool gameOver = false;
    public GameObject gameOverPanel;
    public static GameManager instance;

    public void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        if (gameOver == false)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("00");
    }

}
