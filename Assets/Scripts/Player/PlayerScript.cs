using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D rb;
    float horizontal;

    public float jumpForce;
    public float movementSpeed;
    public float groundRadius;

    bool facingRight;
    public bool isGrounded;
    public bool jump;

    public Transform[] groundPoints;

    public LayerMask ground;

    public GameObject[] puzzlePieces;

    public bool deathDelay;
    public int lives;
    public GameObject[] livesUI;
    public GameUIController uiController;

    public float jumpVelocity = 16f;
    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 2.5f;

    public AudioSource jumpAudio;

    public Animator anim;

    public bool canPlay;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        deathDelay = false;
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        canPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay == true)
        {
            horizontal = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                anim.SetTrigger("takeOff");
            }
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && Input.GetButtonDown("Jump"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
                anim.SetBool("isJumping", true);
            }

            if (rb.velocity.y == 0)
            {
                anim.SetBool("isJumping", false);
            }

            if (horizontal == 0)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }
        }
        else if (canPlay == false)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        isGrounded = IsGrounded();
        Move(horizontal);
        FlipCharacter(horizontal);
    }

    private void Move(float direction)
    {
        rb.velocity = new Vector2(direction * movementSpeed, rb.velocity.y);

        if (isGrounded && jump)
        {
            isGrounded = false;
            jump = false;
            //rb.AddForce(new Vector2(0, jumpForce));
            rb.velocity = Vector2.up * jumpVelocity;
            jumpAudio.Play();
        }
    }

    private void FlipCharacter(float direction)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

        }
    }

    private bool IsGrounded()
    {
        if (rb.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, ground);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void TakeDamage()
    {
        if (lives > 0)
        {
            lives--;
            livesUI[lives].SetActive(false);
            Invoke("DeathTimer", 2f);

        }
        else
        {
            uiController.Death();
        }
    }

    public void DeathTimer()
    {
        deathDelay = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && deathDelay == false)
        {
            deathDelay = true;
            TakeDamage();
        }
        else if (collision.gameObject.tag == "Deathzone")
        {
            uiController.Death();
        }
    }
}