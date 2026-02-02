using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] GameObject HintPanel;
    private void OnTriggerEnter(Collider other)
    {
            HintPanel.SetActive(true);
        
    }

    private void OnTriggerExit(Collider other)
    {
        
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(1f);
        {
            HintPanel.SetActive(false);
            Destroy(gameObject);
        }
    }
}
