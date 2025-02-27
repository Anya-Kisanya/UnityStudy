
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public Text timerText;
    private float currentTime;
    public Text lapsText;
    int lapsnumber = 0;

    public Text laptimeText;
    public Text prevLapText;
    private float currentLapTime;
    private float prevLapTime;
    private float allLaps;
    
    private float timer;
    private bool isButtonClicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (isButtonClicked == true)

        {
            timer += Time.deltaTime;
            currentTime = Mathf.Round(timer);
            timerText.text = currentTime.ToString();
            Debug.Log(timerText.text);
        }
    }

    public void LapsFinishedButtonClick()

    {   
        prevLapTime = currentLapTime;
        currentLapTime = currentTime - prevLapTime - allLaps;
        lapsnumber++;
        allLaps = allLaps + prevLapTime;

        prevLapText.text = prevLapTime.ToString ();
        laptimeText.text = currentLapTime.ToString();
        lapsText.text = lapsnumber.ToString();


    }

    public void StartRaceOnClick()
    {
        isButtonClicked = true;
    }

}
