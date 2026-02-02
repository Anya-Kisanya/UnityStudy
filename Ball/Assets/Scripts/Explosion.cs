using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Power;
    [SerializeField] private ParticleSystem Boom;
    [SerializeField] private Rigidbody PlayerRB;
    private MeshRenderer bombMesh;

    
    void Start()
    {
        bombMesh = GetComponent<MeshRenderer>();
    }

    private void OnCollisionEnter(Collision collision)
    
    {
        Boom.Play();
        bombMesh.enabled = false;
        Vector3 direction = PlayerRB.transform.position - transform.position;
        PlayerRB.AddForce(direction.normalized * Power, ForceMode.Impulse);
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
