using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject[] RotatingObstacles;
    [SerializeField] GameObject MovingObstacle1;
    [SerializeField] GameObject MovingObstacle2;
    [SerializeField] Transform[] Checkpoints;
    private bool forward = true;
    public float Speed;
    private float Timer = 2;

    [SerializeField] GameObject FlipperLeft;
    [SerializeField] GameObject FlipperRight;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject o in RotatingObstacles) 
            o.transform.Rotate(0, 5, 0);

        if (forward)
        {
            MovingObstacle1.transform.position = Vector3.MoveTowards(MovingObstacle1.transform.position, Checkpoints[0].position, Time.deltaTime * Speed);
            MovingObstacle2.transform.position = Vector3.MoveTowards(MovingObstacle2.transform.position, Checkpoints[2].position, Time.deltaTime * Speed);
        }

        else
        {
            MovingObstacle1.transform.position = Vector3.MoveTowards(MovingObstacle1.transform.position, Checkpoints[1].position, Time.deltaTime * Speed);
            MovingObstacle2.transform.position = Vector3.MoveTowards(MovingObstacle2.transform.position, Checkpoints[3].position, Time.deltaTime * Speed);
        }

        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            Timer = 2;
            if (forward) 
                forward = false;
            else forward = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            print("левый");
            FlipLeft();
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            ReleaseLeft();
        }


            if (Input.GetKeyDown(KeyCode.E))
        {
            print("правый");
            FlipRight();
        }
      
        if (Input.GetKeyUp(KeyCode.E))
        {
            ReleaseRight();
        }
    }

    private void FlipLeft()
    {
        var hinge1 = FlipperLeft.GetComponent<HingeJoint>();
        hinge1.useMotor = true;
        var motor = hinge1.motor;
     
    }
    private void ReleaseLeft()
    {
        var hinge1 = FlipperLeft.GetComponent<HingeJoint>();
        hinge1.useMotor = false;
        hinge1.useSpring = true;
    }

    private void FlipRight()
    {
        var hinge1 = FlipperRight.GetComponent<HingeJoint>();
        hinge1.useMotor = true;
        var motor = hinge1.motor;
        
    }

    private void ReleaseRight()
    {
        var hinge1 = FlipperRight.GetComponent<HingeJoint>();
        hinge1.useMotor = false;
        hinge1.useSpring = true;
    }


}
