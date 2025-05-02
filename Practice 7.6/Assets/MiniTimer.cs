using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniTimer : MonoBehaviour
{
    public float MaxTime;
    private float currentTime;
    private bool timerON;

    private int foodCounter;
    public Text FoodCounterText;

   
    public Button AddButton;
    private Image img;
    

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        currentTime = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerON == true)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                currentTime = MaxTime;
                timerON = false;
                AddButton.interactable = true;
                img.color = Color.green;
            }

            img.fillAmount = currentTime / MaxTime;
        }

    }

    public void MiniTimerStart()
    {
       
        foodCounter = int.Parse(FoodCounterText.text);

        if (foodCounter >= 4)
        {
            timerON = true;
            img.color = Color.red;
            AddButton.interactable = false;
        }
        
    }

}

