using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyground : MonoBehaviour
{
    public float slowDownFactor = 0.5f;
    public PlayerMovement script;
    private float startingSpeed;
    private float slowedSpeed;
    public bool isSlowed;

    private void Start()
    {
        startingSpeed = script.moveSpeed;
        slowedSpeed = slowDownFactor * startingSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isSlowed = true;
            script.moveSpeed = slowedSpeed;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        isSlowed = false;
        if (script.isGrounded)
        {
            script.moveSpeed = startingSpeed;
        }
    }
}



