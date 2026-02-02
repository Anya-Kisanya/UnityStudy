
using System.Collections;
using UnityEngine;

using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    [SerializeField] private Text BoxCountText;
    private int BoxCount=0;

    private Animator anim;
    private Rigidbody rb;
    private MeshRenderer boxMesh;
    private Collider boxCol;

    [SerializeField] private ParticleSystem Explosion;
    private Transform ExplosionTransform;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        boxCol = GetComponent<Collider>();
        boxMesh = GetComponentInChildren<MeshRenderer>();
        ExplosionTransform = Explosion.GetComponent<Transform>();
    }

   
    void Update()
    {
       int.TryParse(BoxCountText.text, out BoxCount);
        anim.SetFloat("Velocity", rb.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathTrigger"))
        {
            ExplosionTransform.position = transform.position;
            Explosion.Play();
            boxMesh.enabled = false;
            boxCol.enabled = false;
           StartCoroutine(timer());
           BoxCount++;
           UpdateText();
        }
    }


    private void UpdateText()
    {

        BoxCountText.text = BoxCount.ToString();
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
