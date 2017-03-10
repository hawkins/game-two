using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Transform PlatformGenerator;
    public Transform BackgroundGenerator;
    private Vector3 backgroundStartPoint;
    private Vector3 platformStartPoint;

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] stuffList;

    private ScoreManager theScoreManager;

    public DeathMenu theDeathScreen;

	// Use this for initialization
	void Start () {
        platformStartPoint = PlatformGenerator.position;
        backgroundStartPoint = BackgroundGenerator.position;
        playerStartPoint = thePlayer.transform.position;

        theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RestartGame()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        theDeathScreen.gameObject.SetActive(true);

        //StartCoroutine("RestartGameCo");
    }

    public void Reset()
    {
        theDeathScreen.gameObject.SetActive(false);
        thePlayer.moveSpeed = thePlayer.moveSpeedStore;
        thePlayer.speedMultiplier = thePlayer.speedMultiplierStore;
        thePlayer.mushroomTracker = 0;
        thePlayer.pillTracker = 0;
        thePlayer.shroomCount.text = "x " + thePlayer.mushroomTracker;
        thePlayer.pillCount.text = "x " + thePlayer.pillTracker;
        stuffList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < stuffList.Length; i++)
        {
            stuffList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        PlatformGenerator.position = platformStartPoint;
        BackgroundGenerator.position = backgroundStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.pointMultiplier = 1;
        theScoreManager.scoreIncreasing = true;
    }

    /* public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        stuffList = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < stuffList.Length; i++)
        {
            stuffList[i].gameObject.SetActive(false);
        }

        thePlayer.transform.position = playerStartPoint;
        PlatformGenerator.position = platformStartPoint;
        BackgroundGenerator.position = backgroundStartPoint;
        thePlayer.gameObject.SetActive(true);

        theScoreManager.scoreCount = 0;
        theScoreManager.pointMultiplier = 1;
        theScoreManager.scoreIncreasing = true;
    } */
}
