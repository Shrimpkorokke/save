using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JK_StartTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains("Wall"))
        {
           
            SceneManager.LoadScene(1);
        }
    }
    
    
}
