using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;
    [SerializeField] bool isOnGround = true;
    [SerializeField] float floatForce = 7;
    Rigidbody2D playerRB;
    private GameManager gameManager;


    private float gravityModifier = 1.5f;

    private Animator myAnimator;

    public bool level1 = true;
    public bool level2 = false;
   
    
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        gameManager = GameObject.Find("GameMananager").GetComponent<GameManager>();
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Level1();
        Level2();

       
        myAnimator.SetBool("isOnGround", isOnGround);

    }

   private void Level1()
    {
        if (Input.touchCount > 0 && isOnGround && level1 && gameManager.isGameActive == true)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            isOnGround = false;
        }
    }

    private void Level2()
    {
        if (Input.touchCount > 0 && level2 && gameManager.isGameActive == true)
        {

            playerRB.AddForce(Vector2.up * floatForce);
            isOnGround = false;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ground_2")) && isOnGround == false)
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Stone") || collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            gameManager.GameOver();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Stick"))
        {
            Destroy(other.gameObject);
            gameManager.score += 5;
            gameManager.scoreOverText.text = "Score: " + gameManager.score;
        }

        if (other.gameObject.CompareTag("Lvl_2"))
        {
            level1 = false;
            level2 = true;
            Destroy(GameObject.FindWithTag("SpawnManagerStone"));
        }

    }




}
