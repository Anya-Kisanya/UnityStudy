using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateObject : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    private bool PlayerInRange = false;
    [SerializeField] private GameObject animatedObject;
    private Animator anim;

    private void Awake()
    {
        anim = animatedObject.GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&PlayerInRange)
        {
            PullLever();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInRange = false;
    }

   private void PullLever()
    {
        if (_gameObject.activeSelf)
        _gameObject.SetActive(false);
        else _gameObject.SetActive(true);
        anim.SetTrigger("EPressed");
    }
}
