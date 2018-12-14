using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private Character character;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    private bool gameOver = false;

    private void Awake()
    {
        character = FindObjectOfType<Character>();
    }
 
    public void GameOver()
    {
        gameOver = true;
        gameOverMenu.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1.0f;
    }

    public void GamePause()
    {
        if (!gameOver)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void GameUnPause()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game...");
        Application.Quit();
    }



}
