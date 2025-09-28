using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityOnScript : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject _gameObject;

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        anim.SetTrigger("Pressed");
        _gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
