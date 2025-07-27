using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class superman : MonoBehaviour
{
    public float power;
    public float speed;
    public Transform[] enemies;
    private int enemyCount;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody>() != null)
        {
            Vector3 direction = collision.transform.position - transform.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(direction.normalized * power, ForceMode.Impulse);
            if (enemyCount < enemies.Length - 1) enemyCount++;
            else enemyCount = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemies[enemyCount].position, Time.deltaTime * speed);
    }

   
}
