using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathController : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    private bool Paused = false;
    private MeshRenderer playerMesh;

    [SerializeField] private ParticleSystem Confetti;

    private void Start()
    {
        playerMesh = GetComponent<MeshRenderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathTrigger"))
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            playerMesh.enabled = false;
            Confetti.Play();
            StartCoroutine(timer());
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

    public void PauseGame()
    {
        if (Paused)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;

        Paused = !Paused;
    }
}
