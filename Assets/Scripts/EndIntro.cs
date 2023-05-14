using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndIntro : MonoBehaviour
{
    // Start is called before the first frame update
    void LoadNewScene()
    {
        SceneManager.LoadScene("level1");
    }

}
