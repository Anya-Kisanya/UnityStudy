using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelayScript : MonoBehaviour
{

    [SerializeField] Transform[] Runners;
    public Transform StartPoint;
    
    private Transform TargetTransform;
    private int currentTransformIndex;

    public float Speed;
    public bool Go;

    // Start is called before the first frame update
    void Start()
    {
     TargetTransform = Runners[1];
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Go == true)
        {
            Transform currentRunner = Runners[currentTransformIndex];

            currentRunner.LookAt(TargetTransform);
            currentRunner.position = Vector3.MoveTowards(currentRunner.position, TargetTransform.position, Time.deltaTime * Speed);

            var distance = Vector3.Distance(currentRunner.position, TargetTransform.position);

            if (distance <= 1)


                if (currentTransformIndex <= Runners.Length - 3)
                {
                    currentTransformIndex++;
                    TargetTransform = Runners[currentTransformIndex + 1];
                }

                else
                {
                    currentTransformIndex = Runners.Length - 1;
                    TargetTransform = StartPoint;
                }

            if (currentRunner.position == StartPoint.position)

            {
                TargetTransform = Runners[0];
                Go = false;
                Debug.Log("Конец эстафеты");
            }
            
        }
    }
}
