using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float jumpForce = 5;
    public Rigidbody2D rb ;
    private float move;
    public float speed = 10;
    public bool isFR;
    private bool isJumping;
    public float JumpTimeCounter;
    public float JumpTime = 0.35f;
    private bool onGround;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);



        if (move < 0 && isFR == true )
        {
            flip();
        }
        if (move > 0 && isFR == false)
        {
            flip();
            isFR = true;
        }

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            isJumping = true;
            JumpTimeCounter = JumpTime;
            rb.velocity = Vector2.up * jumpForce;
            
        }

        if(Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (JumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                JumpTimeCounter -= Time.deltaTime;
            }
        }
        else
        {
            isJumping = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }



    }

    private void Update()
    {
        
    }
    void flip()
    {
        isFR = false;
        transform.Rotate(0, 180, 0);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }

    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
