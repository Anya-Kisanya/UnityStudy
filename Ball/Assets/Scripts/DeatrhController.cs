using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathTrigger"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
