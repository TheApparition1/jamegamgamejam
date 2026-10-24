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
    public Transform grabDetect;
    public Transform boxHolder;
    public bool box;
    public bool rightBox;
    public float rayDist;
    public SpriteRenderer playerSpriteRenderer;
    public Sprite[] playerSprites;
    public GameObject deathScreen;
    public TextMeshProUGUI timerText;
    public bool isOnGround;
    public Transform groundCheck;
   
    void Start()
    {
        print("debug2");
        time = 0;
        level = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
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
        if (Input.GetAxis("Vertical") > 0 && jump && isOnGround)
        {
            print("Jump");
            playerRB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
        RaycastHit2D grabCheckL = Physics2D.Raycast(grabDetect.position, Vector2.left, rayDist);
        RaycastHit2D grabCheckR =  Physics2D.Raycast(grabDetect.position, Vector2.right, rayDist);

        RaycastHit2D onGroundCheck = Physics2D.Raycast(groundCheck.position, Vector2.down, 1);
        if (onGroundCheck.collider != null)
        {
            isOnGround = true;
        }
        
        if (grabCheckL.collider.CompareTag("Box") && grabCheckL.collider != null)
        {
            if (Input.GetButtonDown("Interact"))
            {
                
                grabCheckL.collider.gameObject.transform.parent = boxHolder;
                grabCheckL.collider.gameObject.transform.position = boxHolder.position;
                grabCheckL.collider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                box = true;
            }
        }
        else if (grabCheckR.collider.CompareTag("Box") && grabCheckR.collider != null)
        {
            if (Input.GetButtonDown("Interact"))
            {
                grabCheckR.collider.gameObject.transform.parent = boxHolder;
                grabCheckR.collider.gameObject.transform.position = boxHolder.position;
                grabCheckR.collider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                box = true;
            }
        }

        if (Input.GetButtonDown("Interact") && box)
        {
            if (rightBox)
            {
                grabCheckR.collider.gameObject.transform.parent = null;
                grabCheckR.collider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                grabCheckL.collider.gameObject.transform.parent = null;
                grabCheckL.collider.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") | Input.GetAxis("Horizontal") != 0 | Input.GetAxis("Vertical") != 0)
                {
                    playerSprite.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-360f, 360f));
                }
    }

    void OnCollisionEnter2D(Collision col)
    {
        Debug.Log("OnCollisionEnter2D");
        jump = true;

        if (col.gameObject.CompareTag("Spikes"))
        {
            deathScreen.SetActive(true);
        }
        else if (col.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(level+1);
        }
    }
}
