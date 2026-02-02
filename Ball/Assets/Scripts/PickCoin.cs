using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickCoin : MonoBehaviour
{
    private Animator animator;
    private ParticleSystem ps;

    [SerializeField] private Text CoinCountText;
    private int CoinCount = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        int.TryParse(CoinCountText.text, out CoinCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("PickCoin");
        ps.Play();
        StartCoroutine(timer());
        CoinCount++;
        UpdateText();
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(0.7f);
        {
            Destroy(gameObject);
        }
    }

    private void UpdateText()
    {
        CoinCountText.text = CoinCount.ToString();
    }
}
