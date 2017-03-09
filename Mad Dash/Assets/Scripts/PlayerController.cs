using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public string levelToLoad;

    public float moveSpeed;
    private float moveSpeedStore;
    public float jumpForce;
    public float speedMultiplier;
    private float speedMultiplierStore;

    public int mushroomTracker;
    public int pillTracker;

    private Rigidbody2D myRigidbody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Button pauseButton;
    private Collider2D myCollider;

    private Animator myAnimator;

    public GameManager theGameManager;

    private ScoreManager theScoreManager;

    public AudioSource mushroomPickup;
    public AudioSource pillPickup;
    public AudioSource jump;
    public AudioSource death;

    public Text shroomCount;
    public Text pillCount;

	// Use this for initialization
	void Start () {
        /*if(PlayerPrefs.HasKey("moveSpeed"))
        {
            moveSpeed = PlayerPrefs.GetFloat("moveSpeed");
        }
        if(PlayerPrefs.HasKey("speedMultiplier"))
        {
            speedMultiplier = PlayerPrefs.GetFloat("speedMultiplier");
        }
        if(PlayerPrefs.HasKey("pointMultiplier"))
        {
            theScoreManager.pointMultiplier = PlayerPrefs.GetFloat("pointMultiplier");
        }
        if(PlayerPrefs.HasKey("scoreCount"))
        {
            theScoreManager.scoreCount = PlayerPrefs.GetFloat("scoreCount");
        }
        if(PlayerPrefs.HasKey("trackScoreCount"))
        {
            theScoreManager.trackScoreCount = PlayerPrefs.GetFloat("trackScoreCount");
        }
        /*if(PlayerPrefs.HasKey("mushroomTracker"))
        {
            mushroomTracker = PlayerPrefs.GetInt("mushroomTracker");
        }
        if(PlayerPrefs.HasKey("pillTracker"))
        {
            pillTracker = PlayerPrefs.GetInt("pillTracker");
        }*/
        //PlayerPrefs.DeleteAll();

        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();

        myAnimator = GetComponent<Animator>();

        moveSpeedStore = moveSpeed;
        speedMultiplierStore = speedMultiplier;
        
        pauseButton = FindObjectOfType<Button>();
        theScoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {

        pauseButton.enabled = true;
        shroomCount.gameObject.SetActive(true);

        if (moveSpeed >= 75)
        {
            death.Play();
            pauseButton.enabled = false;
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMultiplier = speedMultiplierStore;
            mushroomTracker = 0;
            pillTracker = 0;
            shroomCount.text = "x " + mushroomTracker;
            pillCount.text = "x " + pillTracker;
        }

        if(moveSpeed <= 35)
        {
            death.Play();
            pauseButton.enabled = false;
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMultiplier = speedMultiplierStore;
            mushroomTracker = 0;
            pillTracker = 0;
            shroomCount.text = "x " + mushroomTracker;
            pillCount.text = "x " + pillTracker;
        }

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() )
        {
            if (grounded)
            {
                jump.Play();
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }  
        }

        myAnimator.SetBool("Grounded", grounded);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Mushroom"))
        {
            mushroomPickup.Play();
            other.gameObject.SetActive(false);
            mushroomTracker += 1;
            pillTracker -= 1;
            shroomCount.text = "x " + mushroomTracker;
            pillCount.text = "x " + pillTracker;
            if (theScoreManager.pointMultiplier > 1)
            {
                theScoreManager.pointMultiplier -= 0.25f;
            }
            
            speedMultiplier += 0.15F;
            moveSpeed = 50F;
            moveSpeed = moveSpeed * speedMultiplier;
            
        }

        if (other.gameObject.CompareTag("Pill"))
        {
            pillPickup.Play();
            pillTracker += 1;
            mushroomTracker -= 1;
            shroomCount.text = "x " + mushroomTracker;
            pillCount.text = "x " + pillTracker;
            theScoreManager.pointMultiplier += 0.5f;
            if (moveSpeed > 35)
            {
                if (speedMultiplier > 0) { speedMultiplier -= 0.15F; }
            }
            
            moveSpeed = 50F;
            moveSpeed = moveSpeed * speedMultiplier;
            other.gameObject.SetActive(false);
        }
        
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            death.Play();
            pauseButton.enabled = false;
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMultiplier = speedMultiplierStore;
            mushroomTracker = 0;
            pillTracker = 0;
            shroomCount.text = "x " + mushroomTracker;
            pillCount.text = "x " + pillTracker;
        }

        if (other.gameObject.CompareTag("LevelEnd"))
        {
            //PlayerPrefs.SetFloat("moveSpeed", moveSpeed);
            //PlayerPrefs.SetFloat("speedMultiplier", speedMultiplier);
            //PlayerPrefs.SetFloat("pointMultiplier", theScoreManager.pointMultiplier);
            //PlayerPrefs.SetFloat("scoreCount", theScoreManager.scoreCount);
            //PlayerPrefs.SetFloat("trackScoreCount", theScoreManager.trackScoreCount);
            //PlayerPrefs.SetInt("mushroomTracker", mushroomTracker);
            //PlayerPrefs.SetInt("pillTracker", pillTracker);
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
