using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
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
    public bool box;
    public bool explosive;
    public SpriteRenderer playerSpriteRenderer;
    public Sprite[] playerSprites;
   
    void Start()
    {
        print("debug2");
        time = 0;
        level = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        time += Time.deltaTime;
        player.transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
        if (Input.GetAxis("Vertical") > 0 && jump)
        {
            print("Jump");
            playerRB.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        if (Input.GetButtonDown("Interact") && box)
        {
            Resources.Load<GameObject>("prefabs/Box");
            player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 3);
            box = false;
            playerSpriteRenderer.sprite = playerSprites[0];
        }
    }

    public void collectBox()
    {
        box = true;
        playerSpriteRenderer.sprite = playerSprites[1];
    }

    private void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump") | Input.GetAxis("Horizontal") != 0 | Input.GetAxis("Vertical") != 0)
                {
                    playerSprite.transform.rotation = Quaternion.Euler(0, 0, Random.Range(-360f, 360f));
                }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        jump = true;
    }
}
