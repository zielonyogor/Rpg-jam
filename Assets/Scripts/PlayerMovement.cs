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
    public stickyground script;
    public float moveSpeed = 5f;
    private float originalSpeed;
    float dirX;
    private float dashSpeedMultiplier = 3f;
    private float dashDuration = 0.2f;
    private bool isDashing;
    public bool isGrounded;
    public bool isShielded = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalSpeed = moveSpeed;
        animator.SetBool("right", true);
        animator.SetBool("run", false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded && !isDashing)
        {   
            if (!script.isSlowed)
            {
                rb.AddForce(new Vector2(0, 1f * originalSpeed), ForceMode2D.Impulse);
            }
            else {
            rb.AddForce(new Vector2(0, 1f * moveSpeed), ForceMode2D.Impulse);
            }
            isGrounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Z) && !isDashing && !script.isSlowed)
        {
            Debug.Log("z");
            StartCoroutine(Dash());
        }
    }
    private void FixedUpdate()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        var moveVector = (Vector2)transform.position + new Vector2(dirX, 0f);
        if (dirX > 0f)
        {
            animator.SetBool("right", true);
            animator.SetBool("run", true);
        }
        else if (dirX < 0f)
        {

            animator.SetBool("right", false);
            animator.SetBool("run", true);
        }
        else
        {
            animator.SetBool("run", false);
        }

        gameObject.transform.position = Vector2.MoveTowards(transform.position, moveVector, Time.fixedDeltaTime * moveSpeed);
        //rb.velocity += new Vector2(dirX * moveSpeed, 0f) * Time.fixedDeltaTime;
        

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
        if (collision.gameObject.CompareTag("platform1"))
        {
            if (!script.isSlowed)
            {
                moveSpeed = originalSpeed;
            }
            Debug.Log("kk");
            isGrounded = true;
            isDashing = false;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (isShielded)
            {
                Debug.Log("rucham ci stara");
                rb.AddForce(new Vector2(0f,originalSpeed), ForceMode2D.Impulse);
                isShielded = false;
            }
            else SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("platform1"))
        {
            if (!script.isSlowed)
            {
                moveSpeed = originalSpeed;
            }
            Debug.Log("kk");
            isGrounded = false;
            isDashing = false;
        }
    }
}
