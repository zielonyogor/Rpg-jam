using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickyground : MonoBehaviour
{

    public float slowDownFactor = 0.1f;
    public PlayerMovement script;
    private float startingSpeed;
    private float slowedSpeed;
    public bool isSlowed;

    private void Start()
    {
        slowedSpeed = slowDownFactor * script.moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isSlowed = true;
        if (collision.CompareTag("Player"))
        {
            Debug.Log("aass");
            script.moveSpeed = slowedSpeed;
        }
    }


   // private void OnTriggerExit2D(Collider2D collision)
    //{
       // isSlowed = false;
        //if (script.isGrounded)
        //{
        //    script.moveSpeed = startingSpeed;
        //}
    //}
}



