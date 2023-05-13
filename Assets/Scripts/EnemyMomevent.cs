using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMomevent : MonoBehaviour
{
    public float speed = 1f; // Controls the speed of the saw's movement
    public float amplitude = 1f; // Controls the distance of the saw's movement
    public float offset = 0f; // Offsets the starting position of the saw's movement

    private Vector2 initialPosition; // Stores the initial position of the saw
    private float time = 0f; // Stores the elapsed time since the start of the game
    void Start()
    {
        initialPosition = transform.position;
    }
    void Update()
    {
        time += Time.deltaTime;

        // Calculate the new position based on the sine wave
        float x = initialPosition.x + Mathf.Sin((time * speed) + offset) * amplitude;
        float y = transform.position.y;

        // Update the position of the saw
        transform.position = new Vector2(x, y);
    }
}
