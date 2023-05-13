using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    public float cutsceneTime = 1f;
    public GameObject b;
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ta");
            b.SetActive(true);
            StartCoroutine(DisappearingCoroutine());
        } 
    }
    private IEnumerator DisappearingCoroutine()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(cutsceneTime);
        Debug.Log("2");
        b.SetActive(false);
        gameObject.SetActive(false);
    }
}
