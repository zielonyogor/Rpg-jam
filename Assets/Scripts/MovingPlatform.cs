using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 1f;
    public float amplitude = 3f;
    public float offset = 0f;

    private Vector2 initialPosition;
    private float time = 0f;
    

    void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
        time += Time.deltaTime;
        float x = initialPosition.x + Mathf.Sin((time * speed) + offset) * amplitude;
        float y = transform.position.y;
        transform.position = new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}
