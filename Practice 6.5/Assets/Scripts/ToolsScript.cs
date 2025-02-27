using UnityEngine;
using UnityEngine.UI;

public class ToolsScript : MonoBehaviour
{
    public int[] Pins = {4, 3, 5};
        
    public Text Pin1Text;
    public Text Pin2Text;
    public Text Pin3Text;
   // private int Pin1Value;
    //private int Pin2Value;
    //private int Pin3Value;

    private int answer = 5;

    public GameObject EndGamePanel;
    public GameObject Win;
    public GameObject Fail;

    public Text timerText;
    private float timerTime;
    private float timeLeft;
    private bool timerON = true;

    private void Start()
    {
        float.TryParse(timerText.text, out timerTime);
        SetPinValues();
        ShowResult();
    }

    private void Update()
    {
        if (timerON == true)

        {
            timerTime -= Time.deltaTime;
            timeLeft = Mathf.Round(timerTime);
        }

        if (timeLeft > 0)
        {
            timerText.text = timeLeft.ToString();
        }
        else
        {
            timerText.text = "0";
            EndGamePanel.SetActive(true);
            Fail.SetActive(true);
            timerON = false;
        }
    }

    public void SetPinValues()
    {
        Pins = new int[] { 4, 3, 5 };
       // Pin1Value = 4;
       // Pin2Value = 3;
       // Pin3Value= 5;
        ShowResult();
    }

    public void RestartTimer()
    {
        timerON = true;
        timerTime = 60;
        SetPinValues();
        ShowResult();
    }


    public void Pin1ButtonClick()
    {
        Pins[0]++;
        Pins[1]--;
    }

    public void Pin2ButtonClick() 
    {
        Pins[0]++;
        Pins[1] = Pins[1]+2;
        Pins[2]--;
    }

    public void Pin3ButtonClick()
    {
        Pins[0]--;
        Pins[1]++;
        Pins[2]++;
    }

    public void ShowResult()
    {
        Pin1Text.text = Pins[0].ToString();
        Pin2Text.text = Pins[1].ToString();
        Pin3Text.text = Pins[2].ToString();
    }

    public void CheckAnswer()

    {
       for (int i = 0; i < Pins.Length; i++)
       {
            if (Pins[i] < 0) Pins[i] = 0;
            else if (Pins[i] > 10) Pins[i] = 10;
       }
       ShowResult();
        if (Pins[0] == answer && Pins[1] == answer && Pins[2] == answer) 

        {
            EndGamePanel.SetActive(true);
            Win.SetActive(true);
            timerON = false;
        }
    }

}
