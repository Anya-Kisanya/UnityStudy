using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject Victory;
    private bool Paused = false;
    private MeshRenderer playerMesh;

    [SerializeField] private ParticleSystem Confetti;
    [SerializeField] private ParticleSystem WinConfetti;

    private void Start()
    {
        playerMesh = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathTrigger"))
        {
            
            playerMesh.enabled = false;
            Confetti.Play();
            StartCoroutine(timer());
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (other.CompareTag("VictoryTrigger"))
        {
            WinConfetti.Play();
            
            StartCoroutine(timer2());
        }

    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(0.7f);
        {
            GameOver.SetActive(true);
            PauseGame();
        }
    }

    private IEnumerator timer2()
    {
        yield return new WaitForSeconds(1.5f);
        {
            Victory.SetActive(true);
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
