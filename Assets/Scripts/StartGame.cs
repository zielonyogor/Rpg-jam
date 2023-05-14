using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    
    public void LoadScene(){
        SceneManager.LoadScene(2);
    }

    public void ExitGame(){
        Application.Quit();
        Debug.Log("Game is exiting");
    }

}
