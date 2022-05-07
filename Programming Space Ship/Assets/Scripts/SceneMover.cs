using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneMover : MonoBehaviour
{
    public int index;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            
            SceneManager.LoadScene(index);
        }
    }
}
