using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RelayScript : MonoBehaviour
{

    [SerializeField] Transform[] Runners;
    [SerializeField] GameObject[] Flames;
    
    private int currentIndex;
    private int flameInd;

    public float Speed;
    public bool Go;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       if (Go == true)
       ChangeRunner();
           
        
    }

    public void ChangeRunner()
    {

        if (currentIndex < Runners.Length - 1)
        {
            Runners[currentIndex].position = Vector3.MoveTowards(Runners[currentIndex].position, Runners[currentIndex+1].position, Time.deltaTime * Speed);
            Runners[currentIndex].LookAt(Runners[currentIndex+1]);
            Flames[currentIndex].SetActive(true);

            if (Runners[currentIndex].position == Runners[currentIndex + 1].position)
            {
                Flames[currentIndex].SetActive(false);
                currentIndex++;
                
            }
        }

        else
        {
                Runners[currentIndex].position = Vector3.MoveTowards(Runners[currentIndex].position, Runners[0].position, Time.deltaTime * Speed);
                Runners[currentIndex].LookAt(Runners[0]);
                Flames[currentIndex].SetActive(true);

            if (Runners[currentIndex].position == Runners[0].position)
            {
                Flames[currentIndex].SetActive(false);
                currentIndex = 0;
                
            }
        }

    }

}
