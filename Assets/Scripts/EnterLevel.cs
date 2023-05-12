using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterLevel : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("kurwa");
            SceneManager.LoadScene("level2");
        }
        
    }

}
