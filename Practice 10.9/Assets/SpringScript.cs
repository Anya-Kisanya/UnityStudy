using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringScript : MonoBehaviour
   
{
    [SerializeField] GameObject basePlatform;
 
    private Vector3 target;
    private Rigidbody platform;
    public float power;
    

    private bool BallReady;

    private void OnTriggerEnter(Collider other)
    {
        BallReady = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        platform = GetComponent<Rigidbody>();
        
        target = basePlatform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (BallReady)
        {
            Plunger();
            BallReady = false;
        }

      

    }

    private void Plunger()
    {
        platform.AddForce(target * power, ForceMode.Impulse);
        
    }

}
