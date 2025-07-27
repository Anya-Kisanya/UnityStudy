using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float BoomPower;
    public float Radius;
 

    public void Explosion()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();
        foreach (Rigidbody b in blocks)
        {
            float DistanceFromCenter = Vector3.Distance(transform.position, b.transform.position);
            if (DistanceFromCenter < Radius)
            {
                Vector3 direction = b.transform.position - transform.position;
                b.AddForce(direction.normalized * BoomPower * (Radius - DistanceFromCenter), ForceMode.Impulse);
            }
        }

    }
}

