using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("PlayerInRoom", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("PlayerInRoom", false);
    }
   
}
