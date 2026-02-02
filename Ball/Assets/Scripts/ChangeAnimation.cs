using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(timer());
    }

   // private void OnTriggerEnter(Collider other)
    //{
    //    anim.SetInteger("AnimNumber", Random.Range(1, 4));
   // }

    private IEnumerator timer()
    {
         for (int i = 0; i < 100; i++) 
         {
             yield return new WaitForSeconds(3);
             anim.SetInteger("AnimNumber", Random.Range(1, 4));
             
         }
        
    }
}
