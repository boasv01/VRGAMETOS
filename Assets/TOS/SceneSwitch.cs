using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class SceneSwitch : MonoBehaviour


{
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                SceneManager.LoadScene(2);
            }
        }

        
    
    }
    }
