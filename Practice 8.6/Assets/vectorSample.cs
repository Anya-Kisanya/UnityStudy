using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vectorSample : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    
    public Vector3[] checkpoints;
    private int currentCheckpoint;
   

    public float Speed;
    public bool Go;
    private bool forward;

    void Start()
    {
      transform.LookAt(checkpoints[currentCheckpoint]);
      forward = true;
    }

    void Update()
    {
        if (Go == true)
        {
            transform.LookAt(checkpoints[currentCheckpoint]);
            if (forward == true)
                GoForward();
            else GoBack();
        }

        var distance = Mathf.Round(Vector3.Distance(transform.position, checkpoints[currentCheckpoint]));
        if (distance == 0) 
            Debug.Log(distance);
    }

    private void GoForward()
    {
        transform.position = Vector3.MoveTowards(transform.position, checkpoints[currentCheckpoint], Time.deltaTime * Speed);

       

        if (transform.position == checkpoints[currentCheckpoint] && currentCheckpoint < checkpoints.Length - 1 && forward)
            currentCheckpoint++;

        else if (currentCheckpoint == checkpoints.Length - 1)
        {
            Debug.Log(currentCheckpoint);
            forward = false;
        }
      
    }

    private void GoBack() 
    {
       transform.position = Vector3.MoveTowards(transform.position, checkpoints[currentCheckpoint], Time.deltaTime * Speed);
       

        if (transform.position == checkpoints[currentCheckpoint] && currentCheckpoint > 0)
        {
            currentCheckpoint--;
        }

        else if (currentCheckpoint == 0)
        { 
            forward = true;
        }
    }
}
