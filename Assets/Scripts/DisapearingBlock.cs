using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearingBlock : MonoBehaviour
{
    public float disappearTime = 2f;
    private Collider2D coll;
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("cos");
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisappearingCoroutine());
        }
    }

    private IEnumerator DisappearingCoroutine()
    {
        coll.enabled = false;
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(disappearTime);
        Destroy(gameObject);
    }


}
