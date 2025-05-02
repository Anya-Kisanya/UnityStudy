
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ImageTimer HarvestTimer;
    public ImageTimer EatingTimer;

    public Image RaidTimerIMG;
    public Image PeasantTimerIMG;
    public Image KnightTimerIMG;

    public Button PeasantButton;
    public Button KnightButton;

    public Text ResoursesText;
    public Text RaidText;

    public int StartPeasantCount;
    public int StartKnightCount;
    public int StartFoodCount;

    private int FoodCount;
    private int PeasantCount;
    private int KnightCount;

    public int FoodPerPeasant;
    public int FoodEatenByKnight;
    public int PeasantCost;
    public int KnightCost;

    public int CreatePeasantTime;
    public int CreateKnightTime;

    public int RaidMaxTime;
    public Text RaidPrepText;
    private int RaidPrepTime;
    public Button AddRaidPrepButton;
    public Button SubtractRaidPrepButton;

    public int RaidIncrease;
    public int NextRaid;
    private int RaidClear;

    public GameObject GameOverScreen;
    public GameObject VictoryScreen;

    private float peasantTimer = -2;
    private float knightTimer = -2;
    private float raidTimer;

    public AudioSource BGMusic;
    public AudioSource TimerTicking;

    public AudioSource HarvestSound;
    public AudioSource EatingSound;
    public AudioSource RaidSound;

    public AudioSource PeasantReady;
    public AudioSource KnightReady;

    private int enemyKillCount;
    private int allFoodGathered;
    private int allFoodEaten;

    public Text ResultsText;

    private void Start()
    {
        Time.timeScale = 0;
        SetStartNumbers();
        UpdateText();
    }

    private void Update()
    {
        raidTimer -= Time.deltaTime;
        RaidTimerIMG.fillAmount = raidTimer / RaidMaxTime;

        if (raidTimer <= 0)

        {
            RaidIncrease = Random.Range(0, 4);


            if (RaidPrepTime > 0)
            {
                RaidPrepTime--;
                UpdateText();
                raidTimer = RaidMaxTime;
            }

            else if (RaidPrepTime <= 0)

            {
                raidTimer = RaidMaxTime;
                KnightCount -= NextRaid;
                enemyKillCount = enemyKillCount + KnightCount + NextRaid;
                NextRaid += RaidIncrease;
                RaidClear++;
                RaidSound.Play();
            }
        }



        if (HarvestTimer.Tick)
        {
            FoodCount += PeasantCount * FoodPerPeasant;
            HarvestSound.Play();
            allFoodGathered += PeasantCount * FoodPerPeasant;
        }
        if (EatingTimer.Tick)
        {
            FoodCount -= KnightCount * FoodEatenByKnight;
            EatingSound.Play();
            allFoodEaten += KnightCount * FoodEatenByKnight;
        }
        if (peasantTimer > 0)
        {
            peasantTimer -= Time.deltaTime;
            PeasantTimerIMG.color = Color.red;
            PeasantTimerIMG.fillAmount = peasantTimer / CreatePeasantTime;
        }
        else if (peasantTimer > -1)
        {
            PeasantTimerIMG.fillAmount = 1;
            PeasantTimerIMG.color = Color.green;
            PeasantCount++;
            PeasantButton.interactable = true;
            peasantTimer = -2;
            PeasantReady.Play();
        }

        if (knightTimer > 0)
        {
            knightTimer -= Time.deltaTime;
            KnightTimerIMG.color = Color.red;
            KnightTimerIMG.fillAmount = knightTimer / CreateKnightTime;
        }
        else if (knightTimer > -1)
        {
            KnightTimerIMG.fillAmount = 1;
            KnightTimerIMG.color = Color.green;
            KnightCount++;
            KnightButton.interactable = true;
            knightTimer = -2;
            KnightReady.Play();
        }

        UpdateText();
        ChechResourses();

        if (KnightCount < 0)
        {
            Time.timeScale = 0; 
            GameOverScreen.SetActive(true);
            MusicOff();
        }

        if (PeasantCount >= 50 && FoodCount >= 1000)
        {
            Time.timeScale = 0;
            VictoryScreen.SetActive(true);
            MusicOff();
        }
    }

    public void createPeasant()
    {
        FoodCount -= PeasantCost;
        peasantTimer = CreatePeasantTime;
        PeasantButton.interactable = false;
    }

    public void createKnight()
    {
        FoodCount -= KnightCost;
        knightTimer = CreateKnightTime;
        KnightButton.interactable = false;
    }

    private void UpdateText()
    {
        ResoursesText.text = PeasantCount + "\n" + KnightCount + "\n\n" + FoodCount;
        RaidText.text = RaidPrepTime + "\n" + RaidClear + "\n\n" + NextRaid;
    }
    private void SetStartNumbers()
    {
        KnightCount = StartKnightCount;
        PeasantCount = StartPeasantCount;
        FoodCount = StartFoodCount;
        raidTimer = RaidMaxTime;
        RaidPrepTime = int.Parse(RaidPrepText.text);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        GameOverScreen.SetActive(false);
        VictoryScreen.SetActive(false);
        SetStartNumbers();
        UpdateText();
        BGMusic.Play();
        TimerTicking.Play();
        RaidClear = 0;
        raidTimer = RaidMaxTime;
        RaidPrepTime = int.Parse(RaidPrepText.text);
    }

    public void ChechResourses()
    {
        if (FoodCount < PeasantCost)
            PeasantButton.interactable = false;
        else if (peasantTimer < -1)
            PeasantButton.interactable = true;

        if (FoodCount < KnightCost)
            KnightButton.interactable = false;
        else if (knightTimer < -1)
            KnightButton.interactable = true;
    }

    private void MusicOff()
    {
        BGMusic.Pause();
        TimerTicking.Pause();
    }

    public void AddPrepTime()
    {
        SubtractRaidPrepButton.interactable = true;
        RaidPrepTime++;
        RaidPrepText.text = RaidPrepTime.ToString();
        if (RaidPrepTime >= 3)
            AddRaidPrepButton.interactable = false;
    }
    public void SubtactPrepTime()
    {
        AddRaidPrepButton.interactable = true;
        RaidPrepTime--;
        RaidPrepText.text = RaidPrepTime.ToString();
        if (RaidPrepTime <= 1)
            SubtractRaidPrepButton.interactable = false;
    }

    public void ShowResults()
    {
        if (KnightCount < 0)
            RaidClear--;
        ResultsText.text = allFoodGathered + "\n\n" + allFoodEaten + "\n\n" + PeasantCount + "\n\n\n\n" + enemyKillCount + "\n\n" + RaidClear;
    }

    public void ResetMiniTimers()
    {
        KnightTimerIMG.fillAmount = 1;
        KnightTimerIMG.color = Color.green;
        KnightButton.interactable = true;
        knightTimer = -2;

        PeasantTimerIMG.fillAmount = 1;
        PeasantTimerIMG.color = Color.green;
        PeasantButton.interactable = true;
        peasantTimer = -2;
    }
}
