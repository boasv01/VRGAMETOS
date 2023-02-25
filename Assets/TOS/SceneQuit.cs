using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneQuit : MonoBehaviour
{
    
    int sceneIndex;

    void Start(){
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneIndex - 1);
    }

}
