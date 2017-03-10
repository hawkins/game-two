using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenu;
    public string mainMenuLevel;

    public AudioSource click;

    private PlayerController thePlayer;

    public void PauseGame()
    {
        click.Play();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        click.Play();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        click.Play();
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        FindObjectOfType<GameManager>().Reset();
    }

    public void MainMenu()
    {
        click.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuLevel);
    }
}
