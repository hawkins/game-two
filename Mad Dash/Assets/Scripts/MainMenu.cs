using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public string levelToLoad;
    public string infoSection;

    public AudioSource click;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    public void LoadLevel()
    {
        click.Play();
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadInfo()
    {
        click.Play();
        SceneManager.LoadScene(infoSection);
    }

    public void QuitGame()
    {
        click.Play();
        Application.Quit();
    }
}
