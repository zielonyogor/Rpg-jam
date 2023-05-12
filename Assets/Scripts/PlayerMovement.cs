using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    public float moveSpeed = 5f;
    float dirX;
    private float dashSpeedMultiplier = 3f;
    private float dashDuration = 0.2f;
    private float dashDistance = 5f;
    private bool isDashing;
    private bool isGrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 10f);
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Z) && !isDashing)
        {
            Debug.Log("z");
            StartCoroutine(Dash());
        }
    }
    private IEnumerator Dash()
    {
        isDashing = true;
        float originalSpeed = moveSpeed;
        moveSpeed *= dashSpeedMultiplier;

        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.gravityScale = 0;
        yield return new WaitForSeconds(dashDuration);
        rb.gravityScale = 1;

        moveSpeed = originalSpeed;
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
            Debug.Log("kk");
            isGrounded = true;
            isDashing = false;
        }
    }
}
