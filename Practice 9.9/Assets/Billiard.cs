using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billiard : MonoBehaviour
{
    public float power;
   

    void Start()
    {
        
        Vector3 direction = Vector3.forward;
        GetComponent<Rigidbody>().AddForce(direction.normalized * power, ForceMode.Impulse);
    }

    
}
