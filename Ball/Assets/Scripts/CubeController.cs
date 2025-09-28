
using UnityEngine;

using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    [SerializeField] private Text BoxCountText;
    private int BoxCount=0;

    private Animator anim;
    private Rigidbody rb;

   
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        
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
            Destroy(gameObject);
            BoxCount++;
            UpdateText();
        }
    }


    private void UpdateText()
    {

        BoxCountText.text = BoxCount.ToString();
    }

}
