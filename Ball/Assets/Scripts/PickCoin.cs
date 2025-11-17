using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCoin : MonoBehaviour
{
    private Animator animator;
    private ParticleSystem ps;
    void Start()
    {
        animator = GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("PickCoin");
        ps.Play();
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(0.7f);
        {
            Destroy(gameObject);
        }
    }
}
