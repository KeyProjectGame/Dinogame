using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float jumpForce = 10f;
    [SerializeField] bool isOnGround = true;
    [SerializeField] float floatForce = 7;
    Rigidbody2D playerRB;

    private float gravityModifier = 1.5f;

    private Animator myAnimator;

    public bool level1 = true;
    public bool level2 = false;
    public bool level3 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();

        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Level1();
        Level2();

        myAnimator.SetFloat("Speed", playerRB.velocity.x);
        myAnimator.SetBool("isOnGround", isOnGround);

    }

   private void Level1()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && level1)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            isOnGround = false;
        }
    }

    private void Level2()
    {
        if (Input.GetKey(KeyCode.Space) && level2)
        {
            playerRB.AddForce(Vector2.up * floatForce);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") && isOnGround == false)
        {
            isOnGround = true;
        }

        if (collision.gameObject.CompareTag("Stone") || collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Ground_2") )
        {
            level1 = false;
            level2 = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Stick"))
        {
            Destroy(other.gameObject);
        }
    }

}
