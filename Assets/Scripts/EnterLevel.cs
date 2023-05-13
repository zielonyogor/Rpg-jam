using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnterLevel : MonoBehaviour
{
    public new string name = "level2";

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("shit");
        if (other.CompareTag("Player"))
        {
            Debug.Log("kurwa");
            SceneManager.LoadScene(name);
        }
        
    }

}
