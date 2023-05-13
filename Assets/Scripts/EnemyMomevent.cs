using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMomevent : MonoBehaviour
{
    public float speed = 1f; // Controls the speed of the saw's movement
    public float amplitude = 1f; // Controls the distance of the saw's movement
    public float offset = 0f; // Offsets the starting position of the saw's movement
    public float disapearingTime = 1.5f;

    private Vector2 initialPosition; // Stores the initial position of the saw
    private float time = 0f; // Stores the elapsed time since the start of the game
    private SpriteRenderer sprite;
    void Start()
    {
        initialPosition = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        time += Time.deltaTime;

        // Calculate the new position based on the sine wave
        float x = initialPosition.x + Mathf.Sin((time * speed) + offset) * amplitude;
        float y = transform.position.y;

        // Update the position of the saw
        transform.position = new Vector2(x, y);
            // Change the 'color' property of the 'Sprite Renderer'
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1f - Mathf.Sin(time*disapearingTime));
    }
}
