using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public GameObject playerSprite;
    public Rigidbody2D playerRB;
    private int speed = 7;
    private float jumpForce = 5.7f;
    public bool jump = true;
    public float time;
    public int level;
    public SpriteRenderer playerSpriteRenderer;
    public Sprite[] playerSprites;
    public GameObject deathScreen;
    public TextMeshProUGUI timerText;
    public bool isOnGround;
    public float rayDistDown;
    public Transform groundDetector;
    public bool gameActive;
    public TimeSave save;

    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    void Start()
    {
        time = 0;
        level = SceneManager.GetActiveScene().buildIndex;
        gameActive = true;
    }

    void Update()
    {
        if (gameActive)
        {
            time += Time.deltaTime;
            timerText.text = "Time: " + time;
            if (Input.GetAxis("Horizontal") > 0)
            {
                playerRB.AddForce(transform.right * speed, ForceMode2D.Force);
            }

            if (Input.GetAxis("Horizontal") < 0)
            {
                playerRB.AddForce(transform.right * -speed, ForceMode2D.Force);
            }

            RaycastHit2D groundCheck = Physics2D.Raycast(groundDetector.transform.position, Vector2.down, rayDistDown);
            isOnGround = groundCheck.collider != null && groundCheck.collider.CompareTag("Ground") || groundCheck.collider != null && groundCheck.collider.CompareTag("Box");
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") | Input.GetAxis("Horizontal") != 0 | Input.GetAxis("Vertical") != 0) 
        { 
            playerSprite.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-360f, 360f));
        }
        if (Input.GetAxis("Vertical") > 0 && isOnGround)
        {
            playerRB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        jump = true;

        if (col.gameObject.CompareTag("Spikes"))
        {
            deathScreen.SetActive(true);
            gameActive = false;
            print("Deadedified HA take that");
        }
        else if (col.gameObject.CompareTag("Finish") && level <= 3)
        {
            save.levelTimes[level - 1] = time;
            SceneManager.LoadScene(level+1);
        }
    }
}
