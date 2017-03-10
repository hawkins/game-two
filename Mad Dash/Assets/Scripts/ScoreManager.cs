using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
    public Text hiScoreText;

    public float scoreCount;
    public float trackScoreCount;
    public float hiScoreCount;

    public float pointsPerSecond;
    public float pointMultiplier;

    public bool scoreIncreasing;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("HighScore"))
        {
            hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
        if (PlayerPrefs.HasKey("scoreCount"))
        {
            scoreCount = PlayerPrefs.GetFloat("scoreCount");
        }
        if (PlayerPrefs.HasKey("trackScoreCount"))
        {
            trackScoreCount = PlayerPrefs.GetFloat("trackScoreCount");
        }
    }
	
	// Update is called once per frame
	void Update () {

        if(scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
            PlayerPrefs.SetFloat("scoreCount", scoreCount);
        }

        if(trackScoreCount > hiScoreCount)
        {
            hiScoreCount = trackScoreCount;
            PlayerPrefs.SetFloat("HighScore", hiScoreCount);
        }

        trackScoreCount = scoreCount * pointMultiplier;
        PlayerPrefs.SetFloat("trackScoreCount", trackScoreCount);
        scoreText.text = "Score: " + Mathf.Round(scoreCount) + " x " + pointMultiplier;
        hiScoreText.text = "High Score: " + (Mathf.Round(hiScoreCount));

	}
}
