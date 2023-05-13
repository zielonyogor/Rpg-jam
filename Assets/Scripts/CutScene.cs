using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public float cutsceneTime = 2f;
    public string nextLevelName = "scena";
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(CutSceneCoroutine());
        }
    }
    private IEnumerator CutSceneCoroutine()
    {
        yield return new WaitForSeconds(cutsceneTime);
        SceneManager.LoadScene(nextLevelName);
    }
}
