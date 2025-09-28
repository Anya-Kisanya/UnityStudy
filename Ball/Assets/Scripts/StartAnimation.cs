using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject _gameObject;
    private Animator objectAnimator;

    private void Start()
    {
        anim = GetComponent<Animator>();
        objectAnimator = _gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Pressed");
        objectAnimator.SetTrigger("Pressed");
    }
}
