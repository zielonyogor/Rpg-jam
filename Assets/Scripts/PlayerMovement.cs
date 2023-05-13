using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public stickyground script;
    public float moveSpeed = 5f;
    private float originalSpeed;
    float dirX;
    private float dashSpeedMultiplier = 3f;
    private float dashDuration = 0.2f;
    private bool isDashing;
    public bool isGrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalSpeed = moveSpeed;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed*2);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Z) && !isDashing && !script.isSlowed)
        {
            Debug.Log("z");
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        isDashing = true;
        moveSpeed *= dashSpeedMultiplier;

        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.gravityScale = 0;
        yield return new WaitForSeconds(dashDuration);
        rb.gravityScale = 1;

        if (!script.isSlowed)
        {
            moveSpeed = originalSpeed;
        }
        if (isGrounded)
        {
            isDashing = false;
        }
        
    }
    private void FixedUpdate()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX* moveSpeed, rb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!script.isSlowed)
            {
                moveSpeed = originalSpeed;
            }
            Debug.Log("kk");
            isGrounded = true;
            isDashing = false;
        }
    }
}
