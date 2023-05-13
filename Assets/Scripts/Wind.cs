using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    private float windInterval = 3f;
    private float windTimer = 0f;
    [SerializeField] float windForce = 5f;
    private bool isBlowing = false;
    public Rigidbody2D player_rb;

    private void Update()
    {
        windTimer += Time.deltaTime;
        if (windTimer >= windInterval)
        {
            windTimer = 0f;
            isBlowing = !isBlowing;
            if (isBlowing)
            {
                Blow();
            }
        }
    }

    private void Blow()
    {
        Vector2 windDirection = new Vector2(-1f, 0f).normalized;
        player_rb.AddForce(windDirection * windForce, ForceMode2D.Impulse);
        Debug.Log("kupa");
    }
}