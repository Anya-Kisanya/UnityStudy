using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorutineSample : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    private bool Paused;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathTrigger"))
        {
            StartCoroutine(timer());
        }
    }
    private IEnumerator timer()
    {
        yield return new WaitForSeconds(3);
        {
            GameOver.SetActive(true);
            Debug.Log("Ping");
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (Paused)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
        Paused = !Paused;
    }
}
