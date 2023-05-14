using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    public stickyground script;
    public float moveSpeed = 5f;
    private float originalSpeed;
    public float jumpForce;
    float dirX;
    private float dashSpeedMultiplier = 2f;
    private float dashDuration = 0.2f;
    private bool isDashing = false;
    public bool isShielded = false;
    private bool canWallJump = true;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
        originalSpeed = moveSpeed;
        jumpForce = 0.9f * originalSpeed;
        animator.SetBool("right", true);
        animator.SetBool("run", false);
        animator.SetBool("jump", false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (canWallJump && IsWalled())
            {
                canWallJump = false;
                animator.SetBool("jump", true);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            else if(IsGrounded())
            {
                animator.SetBool("jump", true);
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
            //isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Z) && !isDashing && !script.isSlowed)
        {
            Debug.Log("z");
            isDashing = true;
            StartCoroutine(Dash());
        }

    }
    private void FixedUpdate()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        //the most precious thing my baby
        var moveVector = (Vector2)transform.position + new Vector2(dirX, 0f);

        
        if (dirX > 0f)
            {
                animator.SetBool("right", true);
            }
        else if (dirX < 0f)
            {
                animator.SetBool("right", false);
            }

        if (IsGrounded())
        {

            if (dirX != 0f)
            {
                animator.SetBool("run", true);
            }
            else
            {
                animator.SetBool("run", false);
            }
        }
        if (IsWalled() && !IsGrounded())
        {
            animator.SetBool("slide", true);
        }
        else
        {
            animator.SetBool("slide", false);
        }

        gameObject.transform.position = Vector2.MoveTowards(transform.position, moveVector, Time.fixedDeltaTime * moveSpeed);
        //rb.velocity += new Vector2(dirX * moveSpeed, 0f) * Time.fixedDeltaTime;
        

    }

    private bool IsGrounded()
    {
        float extraHeightText = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.down, boxCollider2d.bounds.extents.y + extraHeightText, groundLayer);
        if (raycastHit.collider != null)
        {
            animator.SetBool("jump", false);
            canWallJump = true;
            isDashing = false;
            return true;
        }
        animator.SetBool("jump", true);
        return false;
    }

    private bool IsWalled()
    {
        float extraWidthText = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.right, boxCollider2d.bounds.extents.x + extraWidthText, wallLayer);
        if (raycastHit.collider != null)
            return true;
        raycastHit = Physics2D.Raycast(boxCollider2d.bounds.center, Vector2.left, boxCollider2d.bounds.extents.x + extraWidthText, wallLayer);
        return raycastHit.collider != null;
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
        if (IsGrounded())
        {
            isDashing = false;
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isShielded)
            {
                rb.AddForce(new Vector2(0f,originalSpeed), ForceMode2D.Impulse);
                isShielded = false;
            }
            else SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
