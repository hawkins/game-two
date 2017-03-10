using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DeathMenu : MonoBehaviour {

    public string mainMenuLevel;
    public Text finalHighScore;
    private PlayerController thePlayer;
    
    private ScoreManager theScoreManager;

    public AudioSource click;

    private void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        thePlayer = FindObjectOfType<PlayerController>();

    }

    public void RestartGame()
    {
        click.Play();
        FindObjectOfType<GameManager>().Reset();
    }

    public void MainMenu()
    {
        click.Play();
        SceneManager.LoadScene(mainMenuLevel);
    }

    private void Update()
    {
        finalHighScore.text = "Game Over!" + System.Environment.NewLine + "High Score: " + Mathf.Round(theScoreManager.hiScoreCount);
    }
}
