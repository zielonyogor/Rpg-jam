using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float windInterval = 3f;
    private float windTimer = 0f;
    [SerializeField] float windForce = 5f;
    private bool isBlowing = false;
    public Rigidbody2D player_rb;
    private bool inArea = false;
    public float direction = -1f;

    private void Update()
    {
        windTimer += Time.deltaTime;
        if (windTimer >= windInterval)
        {
            windTimer = 0f;
            isBlowing = !isBlowing;
            if (isBlowing && inArea)
            {
                Debug.Log("pipa");
                Blow();
            }
        }
    }

    private void Blow()
    {
        Vector2 windDirection = new Vector2(direction, 0f).normalized;
        player_rb.AddForce(windDirection * windForce, ForceMode2D.Impulse);
        Debug.Log("kupa");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            inArea = false;
        }
    }
}