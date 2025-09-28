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
        HintPanel.SetActive(false);
    }
}
