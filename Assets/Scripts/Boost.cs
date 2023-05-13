using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public PlayerMovement script;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("your mom");
            Destroy(this.gameObject);
            script.isShielded = true;
        }
    }
}
