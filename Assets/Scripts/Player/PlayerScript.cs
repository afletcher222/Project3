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


    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
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

        if(isGrounded && jump)
        {
            isGrounded = false;
            jump = false;
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void FlipCharacter(float direction)
    {
        if(horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;

        }
    }

    private bool IsGrounded()
    {
        if(rb.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, ground);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if(colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
