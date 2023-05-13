using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Parallax : MonoBehaviour
{
    public PixelPerfectCamera cam;
    public Transform player;
    Vector2 startPosition;

    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;
    Vector2 parallaxFactor;

    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    public void Update()
    {
        transform.position = startPosition + travel;
    }
}
