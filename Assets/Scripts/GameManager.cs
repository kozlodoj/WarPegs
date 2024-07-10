using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    public float ballPower = 5;
    public float reloadRate = 5;
    public float reloadPerSec = 0.06f;
    public float buff = 2;
    public float respawn = 2;
    public float intialStat = 100f;
    public int baseHP;
    public float initialBallCharge;

    public int gold;
    public int diamonds;
    public int currentGold;

    public bool randomSpawn;
    public bool reactivatePegsOnSpawn;

    public bool isUnitTwoActive = false;
    public bool isUnitThreeActive = false;

    public bool isPerkOneActive = false;
    public bool isPerkTwoActive = false;

    public float perkOneRecharge;
    public float perkTwoRecharge;

    public bool gameOver = false;

    public int unitTwoCost = 1000;
    public int unitThreeCost = 5000;

    public int perkOneCost = 300;
    public int perkTwoCost = 500;

    public int reloadCost;
    public int hPCost;
    public int buffCost;

    public bool storyMode;

    public float cameraScale;

    public bool joyStickActive;

    public bool freezeGame = false;

    public bool tutorial = true;

    public int playerEra;
    public int playerEraCount;
    public int enemyEra;
    public int evolveCost;
    public bool canNextTimeline = false;
    public bool allEnemiesKilled = false;

    public int timeLine;
    public float timeLineModifier = 1f;

    public int bounces;
    public int ballsShot;
    public int enemiesDefeated;
    public int unitTwoSpawned;
    public int unitThreeSpawned;
    public int goldCollected;
    public float buffGathered;

    public int dailyNum = 1;

    private SaveScript save;


    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        save = gameObject.GetComponent<SaveScript>();
        MakeNewGameData();
        CameraScale();
        LoadGame();
        SetReloadTime();
        

    }
    private void OnEnable()
    {
        if (tutorial)
        {
            LevelSelect(6);
        }
    }

    public void LevelSelect(int levelNum)
    {
        SetReloadTime();
        currentGold = 0;
        Time.timeScale = 1;
        if (levelNum > 5)
            storyMode = true;
        else
            storyMode = false;
        SaveGame();
        SceneManager.LoadScene(levelNum);
        gameOver = false;

    }

    public void BackToMenu()
    {
        currentGold = 0;
        SaveGame();
        SceneManager.LoadScene(5);
        gameOver = false;
        tutorial = false;
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        UIScript UI = GameObject.Find("UI").GetComponent<UIScript>();
        UI.ActivateGameOverUI();
        UI.KillOutline();
    }
    public void AddGold(int amount)
    {
        gold += amount;
        currentGold += amount;
        if (SceneManager.GetActiveScene().name != "Story Menu" && !gameOver && !tutorial)
            goldCollected += amount;
        ManageDaily();
        if (SceneManager.GetActiveScene().name == "Story Menu")
        {
            GameObject.Find("UI").GetComponent<StoryUI>().SetGoldText(gold);
        }
        else
        GameObject.Find("UI").GetComponent<UIScript>().SetCollectedGold(currentGold);
    }

    public void AddDiamond(int amount)
    {
        diamonds += amount;
       
        if (SceneManager.GetActiveScene().name == "Story Menu")
        {
            GameObject.Find("UI").GetComponent<StoryUI>().SetDiamondText(diamonds);
        }
        else
            GameObject.Find("UI").GetComponent<UIScript>().SetDiamonds(diamonds);
    }
    public void BuyUnit(int num)
    {
        SaveGame();
        //buy unit 1
        if (num == 2 && !isUnitTwoActive)
        {
            AddGold(-unitTwoCost);
            isUnitTwoActive = true;
        }
        //buy unit 2
        else if (num == 3 && !isUnitThreeActive)
        {
            AddGold(-unitThreeCost);
            isUnitThreeActive = true;
        }
        //evolve
        else if (num == 4)
        {
            
                gold = 0;
                playerEra++;
                enemyEra = 0;
                NextEra();
            
        }
        else if (num == 5)
        {
          
                NextTimeLine();
          
        }
    }
    public void BuyPerk(int num)
    {
        SaveGame();
        if (num == 1 && !isPerkOneActive)
        {
            AddDiamond(-perkOneCost);
            isPerkOneActive = true;
        }
        if (num == 2 && !isPerkTwoActive)
        {
            AddDiamond(-perkTwoCost);
            isPerkTwoActive = true;
        }

    }

    public void BuyReloadTime()
    {
        SaveGame();
        reloadPerSec += 0.005f;
        reloadRate = 1 / reloadPerSec;
        AddGold(-reloadCost);
        reloadCost = (int)(reloadCost * 1.2f);
    }
    public void BuyHP()
    {
        SaveGame();
        if (playerEra == 0)
        {
            baseHP = (int)(baseHP + 1);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);
        }
        else if (playerEra == 1)
        {
            baseHP = (int)(baseHP + 15);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);

        }
        else if (playerEra == 2)
        {
            baseHP = (int)(baseHP + 40);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);

        }
        else if (playerEra == 3)
        {
            baseHP = (int)(baseHP + 150);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);

        }
        else if (playerEra == 4)
        {
            baseHP = (int)(baseHP + 450);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);

        }
        else if (playerEra == 5)
        {
            baseHP = (int)(baseHP + 1200);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);

        }
    }
    public void BuyBuff()
    {
        SaveGame();
        buff++;
        AddDiamond(-buffCost);
        buffCost = (int)(buffCost * 2f);
    }

    private void CameraScale()
    {
        if ((float)Screen.height / (float)Screen.width >= 2f)
        {
            GameObject camera = GameObject.Find("Main Camera");
            cameraScale = ((float)Screen.height / (float)Screen.width) * 5f;
            camera.GetComponent<Camera>().orthographicSize = cameraScale;
        }
        else
        {
            GameObject camera = GameObject.Find("Main Camera");
            cameraScale = 10;
            camera.GetComponent<Camera>().orthographicSize = cameraScale;
        }

    }
    public void FreezeTow()
    {
        if (!freezeGame)
            freezeGame = true;
       
    }
    public void UnFreezeTow()
    {
        if (freezeGame)
            freezeGame = false;
    }
    private void SetReloadTime()
    {
        reloadRate = 1 / reloadPerSec;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void NextEra()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            GameObject.Find("UI").GetComponent<StoryUI>().NextEra();
        }
        //deactivate unit 2 & 3
        isUnitTwoActive = false;
        isUnitThreeActive = false;
        gold = 0;
        reloadPerSec = 0.06f;
        SetReloadTime();
        //set costs
        if (playerEra == 0)
        {
            reloadCost = 9;
            hPCost = 30;
            unitTwoCost = 150;
            unitThreeCost = 400;
            evolveCost = 2000;
            baseHP = 2;

        }
        else if (playerEra == 1)
        {
            reloadCost = 42;
            hPCost = 140;
            unitTwoCost = 700;
            unitThreeCost = 1850;
            evolveCost = 9320;
            baseHP = 15;

        }
        else if (playerEra == 2)
        {
            reloadCost = 155;
            hPCost = 517;
            unitTwoCost = 2590;
            unitThreeCost = 6890;
            evolveCost = 34450;
            baseHP = 40;

        }
        else if (playerEra == 3)
        {
            reloadCost = 529;
            hPCost = 1763;
            unitTwoCost = 8815;
            unitThreeCost = 23500;
            evolveCost = 117500;
            baseHP = 150;
        }
        else if (playerEra == 4)
        {
            reloadCost = 1587;
            hPCost = 5290;
            unitTwoCost = 26450;
            unitThreeCost = 70500;
            evolveCost = 352600;
            baseHP = 450;

        }
        else if (playerEra == 5)
        {
            reloadCost = 4104;
            hPCost = 13680;
            unitTwoCost = 68400;
            unitThreeCost = 182400;
            evolveCost = 912000;
            baseHP = 1200;

        }
        SaveGame();

    }

    public void ManageDaily()
    {
        if (SceneManager.GetActiveScene().name != "Story Menu" && !tutorial)
        {
            
            if (dailyNum == 1)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (goldCollected >= 100)
                {
                    AddDiamond(40);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
            else if (dailyNum == 2)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (bounces >= 150)
                {
                    AddDiamond(50);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
             else if (dailyNum == 3)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (ballsShot >= 15)
                {
                    AddDiamond(40);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
            else if (dailyNum == 4)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (unitTwoSpawned >= 15)
                {
                    AddDiamond(50);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
            else if (dailyNum == 5)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (enemiesDefeated >= 20)
                {
                    AddDiamond(50);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
            else if (dailyNum == 6)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (unitThreeSpawned >= 7)
                {
                    AddDiamond(70);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
            else if (dailyNum == 7)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (buffGathered >= 1)
                {
                    AddDiamond(100);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
        }
    }
    public void ResetDailyProgress()
    {
        bounces = 0;
        goldCollected = 0;
        ballsShot = 0;
        enemiesDefeated = 0;
        unitTwoSpawned = 0;
        unitThreeSpawned = 0;
        buffGathered = 0;
    }

    public void LoadGame()
    {
        save.LoadGame();
    }
    public void SaveGame()
    {
        save.SaveGame();
    }
    public void MakeNewGameData()
    {
        save.NewGameFile();
    }
    public void NewGame()
    {
        save.LoadNewGame();
    }
    public void DeleteSave()
    {
        save.DeleteSaveFiles();
    }
    public void NextTimeLine()
    {
        timeLine++;
        timeLineModifier *= 1.1f;
        playerEra = 0;
        enemyEra = 0;
        //set gold and stats
        gold = 0;
        reloadPerSec = 0.06f;
        SetReloadTime();
        baseHP = 2;
        //deactivate unit 2 & 3
        isUnitTwoActive = false;
        isUnitThreeActive = false;
        //change the cost of units and evolution
        unitThreeCost = 1200;
        unitTwoCost = 400;
        evolveCost = 2000;
        canNextTimeline = false;
        GameObject.Find("UI").GetComponent<StoryUI>().NextEra();
       
       

    }
}
